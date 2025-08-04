import requests
import time
from bs4 import BeautifulSoup
import csv
from decimal import Decimal
from urllib.parse import urljoin
import re

HEADERS = {
    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36"
}

BASE_URL = "https://www.ebay.com"
CATEGORY_URL = "https://www.ebay.com/b/Car-Truck-Crankshafts/33616/bn_560110"

def get_product_links(start_page=1, end_page=5):
    product_links = []
    for page in range(start_page, end_page + 1):
        url = f"{CATEGORY_URL}?_pgn={page}"
        print(f"Scraping category page: {url}")
        response = requests.get(url, headers=HEADERS, timeout=10)
        if response.status_code != 200:
            print(f"Failed to fetch category page {page}.")
            break

        soup = BeautifulSoup(response.text, "html.parser")
        product_items = soup.find_all("a", class_="bsig__title__wrapper")
        if not product_items:
            print("No more products found. Stopping.")
            break

        for item in product_items:
            href = item.get("href")
            if href:
                full_url = urljoin(BASE_URL, href)
                match = re.search(r"(https://www\.ebay\.com/itm/\d+)", full_url)
                if match:
                    clean_url = match.group(1)
                    product_links.append(clean_url)

        time.sleep(2)
    return product_links

def scrape_product(url):
    try:
        response = requests.get(url, headers=HEADERS, timeout=10)
        if response.status_code != 200:
            print(f"Failed to fetch {url}")
            return []

        soup = BeautifulSoup(response.text, "html.parser")

        # Collect shared product data
        base_data = {}
        product_name = soup.find("h1", class_="x-item-title__mainTitle")
        base_data["Product Name"] = product_name.get_text(strip=True) if product_name else "No product name found"

        price = soup.find("div", class_="x-price-primary")
        base_data["Price"] = price.get_text(strip=True) if price else "No price found"

        base_data["Product URL"] = url
        base_data["Category URL"] = CATEGORY_URL

        # Get dynamic labels and values
        sections = soup.find_all('dl', {'data-testid': 'ux-labels-values'})
        for section in sections:
            label_tags = section.find_all('dt')
            value_tags = section.find_all('dd')
            for label_tag, value_tag in zip(label_tags, value_tags):
                label = label_tag.get_text(strip=True)
                value = value_tag.get_text(strip=True)
                base_data[label] = value

        # Get product image
        image_div = soup.find("div", class_="ux-image-grid-container")
        if image_div:
            img_tag = image_div.find("img")
            if img_tag:
                image_url = img_tag.get("data-lazy-src") or img_tag.get("src")
                if image_url and not image_url.startswith("http"):
                    image_url = BASE_URL + image_url
                base_data["Image URL"] = image_url
            else:
                base_data["Image URL"] = "No image found"

        # Extract table data
        final_rows = []
        table = soup.find('table')
        if not table:
            return [base_data]

        rows = table.find_all('tr')[1:]  # Skip the header
        for row in rows:
            cols = row.find_all('td')
            if len(cols) >= 5:
                year = cols[0].get_text(strip=True)
                make = cols[1].get_text(strip=True)
                model = cols[2].get_text(strip=True)
                trim = cols[3].get_text(strip=True)
                engine = cols[4].get_text(strip=True)
                notes = cols[5].get_text(strip=True) if len(cols) > 5 else "Empty"

                # Merge table row with shared product data
                combined_data = base_data.copy()
                combined_data.update({
                    "Year": year,
                    "Make": make,
                    "Model": model,
                    "Trim": trim,
                    "Engine": engine,
                    "Notes": notes
                })

                final_rows.append(combined_data)

        return final_rows

    except Exception as e:
        print(f"Error scraping {url}: {e}")
        return []

def scrape_all_products():
    product_links = get_product_links(start_page=1, end_page=5)  # Set page range here
    all_data = []
    all_headers = set()  # Use a set to store all unique headers

    for idx, link in enumerate(product_links, start=1):
        print(f"\n📦 Scraping product {idx}/{len(product_links)}: {link}")
        data = scrape_product(link)
        if data:
            all_data.extend(data)
            for row in data:
                all_headers.update(row.keys())  # Add headers from each row
        time.sleep(2)

    if not all_data:
        print("⚠️ No product data collected.")
        return

    headers = list(all_headers)  # Convert the set to a list
    with open("Crankshafts.csv", mode="w", newline="", encoding="utf-8") as f:
        writer = csv.DictWriter(f, fieldnames=headers)
        writer.writeheader()
        for row in all_data:
            writer.writerow(row)

    print("\n✅ All product data saved to 'Crankshafts.csv'")

scrape_all_products()
