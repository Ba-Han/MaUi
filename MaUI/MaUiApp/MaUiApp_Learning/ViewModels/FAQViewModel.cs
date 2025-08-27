using CommunityToolkit.Mvvm.ComponentModel;
using MaUiApp_Learning.Views;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MaUiApp_Learning.ViewModels
{
    public partial class FAQViewModel : ObservableObject
    {
        // List of available categories for the dropdown
        public ObservableCollection<string> Categories { get; } = new ObservableCollection<string>
        {
            "All",
            "General",
            "Account & User",
            "Order",
			"Return",
			"E-Learning",
			"Reward Points"
		};

        [ObservableProperty]
        private string? selectedCategory;

        [ObservableProperty]
        private ObservableCollection<FaqItem> faqItems;

        private List<FaqItem> allFaqItems;
		public ICommand ItemTappedCommand { get; }

		[ObservableProperty]
		private string? searchText;

		// Constructor
		public FAQViewModel()
        {
			allFaqItems = new List<FaqItem>
            {
	            new FaqItem
	            {
		            Question = "What is E-Platform?",
		            Answer = "E-Platform NHF is a website / platform that provide a site for customer to place order / buy products. After select product, select mode of payments and after that order will check out and iterm will delivery to customer accordingly.",
		            Category = "General",
		            Date = new DateTime(2020, 2, 7, 8, 0, 0)
	            },
	            new FaqItem
	            {
		            Question = "If I need for assistance, what shall I need to do?",
		            Answer = "You may contact directly to our customer service who are able to respond your queries during office hours 9am - 5:30pm weekday except for public holiday. Contact us at 03-3377 8288 or email ot enquriies@eautopartner.com",
		            Category = "General",
					Date = new DateTime(2020, 2, 7, 8, 0, 0)
				},
	            new FaqItem
	            {
		            Question = "How do I apply for E-Platform account?",
		            Answer = "Please ensure your account is activated. If the issue persists, contact support.",
		            Category = "Account & User"
				},
				new FaqItem
				{
					Question = "What documents do I need to apply E-Platform account?",
					Answer = "Please ensure your account is activated. If the issue persists, contact support.",
					Category = "Account & User"
				},
				new FaqItem
				{
					Question = "How do I update my details?",
					Answer = "Please ensure your account is activated. If the issue persists, contact support.",
					Category = "Account & User"
				},
				new FaqItem
				{
					Question = "What shall I do if I forgot my ID / Password?",
					Answer = "Please ensure your account is activated. If the issue persists, contact support.",
					Category = "Account & User"
				},
				new FaqItem
	            {
		            Question = "Why I can't log in to the e-platform although my password & ID was correct?",
		            Answer = "Yes, all customer information is protected according to our privacy policy.",
		            Category = "Account & User"
				},
				new FaqItem
				{
					Question = "Is the Information I provided confidential?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Account & User"
				},
				new FaqItem
				{
					Question = "How do I change language in NHF pages?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Account & User"
				},
				new FaqItem
				{
					Question = "How to order through e-platform?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Order"
				},
				new FaqItem
				{
					Question = "How was the deliver charges applied?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Order"
				},
				new FaqItem
				{
					Question = "Why I didn't received my order although I had paid?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Order"
				},
				new FaqItem
				{
					Question = "Can I select delivery address which is not registered in the system?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Order"
				},
				new FaqItem
				{
					Question = "How do I submit the my order?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Order"
				},
				new FaqItem
				{
					Question = "Can I cancel or amend mmy order?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Order"
				},
				new FaqItem
				{
					Question = "How do I know my order's status?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Order"
				},
				new FaqItem
				{
					Question = "Does adding an item to my cart mean that I've already reserver it?",
					Answer = "Yes, all customer information is protected according to our privacy policy.",
					Category = "Order"
				},
				new FaqItem
				{
					Question = "Can I request for refund if the item purchased have quality issue?",
					Answer = "No, T&C applied. For more information, please refer to Term of Use-Return policy.",
					Category = "Return"
				},
				new FaqItem
				{
					Question = "Step 1 - How to use E-Platform",
					Answer = "No, T&C applied. For more information, please refer to Term of Use-Return policy.",
					Category = "E-Learning"
				},
				new FaqItem
				{
					Question = "Step 2 - Product Search",
					Answer = "No, T&C applied. For more information, please refer to Term of Use-Return policy.",
					Category = "E-Learning"
				},
				new FaqItem
				{
					Question = "Step 3 - Place Order and Checkout for Delivery",
					Answer = "No, T&C applied. For more information, please refer to Term of Use-Return policy.",
					Category = "E-Learning"
				},
				new FaqItem
				{
					Question = "Step 4 - Order Confirmation",
					Answer = "No, T&C applied. For more information, please refer to Term of Use-Return policy.",
					Category = "E-Learning"
				},
				new FaqItem
				{
					Question = "Step 5 - Understand Promotion",
					Answer = "No, T&C applied. For more information, please refer to Term of Use-Return policy.",
					Category = "E-Learning"
				},
				new FaqItem
				{
					Question = "Introduction to Reward Points",
					Answer = "No, T&C applied. For more information, please refer to Term of Use-Return policy.",
					Category = "Reward Points"
				},
				new FaqItem
				{
					Question = "What is Reward Point",
					Answer = "No, T&C applied. For more information, please refer to Term of Use-Return policy.",
					Category = "Reward Points"
				}
			};

			FaqItems = new ObservableCollection<FaqItem>(allFaqItems);
			ItemTappedCommand = new Command<FaqItem>(OnItemTapped);
		}

		private async void OnItemTapped(FaqItem item)
		{
			if (item == null) return;

			await Shell.Current.GoToAsync(nameof(FAQDetailPage), true, new Dictionary<string, object>
			{
				{ "SelectedFAQ", item }
			});
		}

		partial void OnSearchTextChanged(string value)
		{
			FilterSearchFaqs();
		}

		private void FilterSearchFaqs()
		{
			IEnumerable<FaqItem> filtered = allFaqItems;

			// Filter by category
			if (!string.IsNullOrWhiteSpace(SelectedCategory) && SelectedCategory != "All")
			{
				filtered = filtered.Where(f => f.Category?.Equals(SelectedCategory, StringComparison.OrdinalIgnoreCase) == true);
			}

			// Filter by search text
			if (!string.IsNullOrWhiteSpace(SearchText))
			{
				string lowerSearch = SearchText.ToLower();
				filtered = filtered.Where(f =>
					(f.Question?.ToLower().Contains(lowerSearch) ?? false) ||
					(f.Answer?.ToLower().Contains(lowerSearch) ?? false));
			}

			FaqItems = new ObservableCollection<FaqItem>(filtered);
		}


		partial void OnSelectedCategoryChanged(string value)
        {
            FilterFaqs();
        }

        private void FilterFaqs()
        {
            if (string.IsNullOrWhiteSpace(SelectedCategory) || SelectedCategory == "All")
            {
                FaqItems = new ObservableCollection<FaqItem>(allFaqItems);
            }
            else
            {
                FaqItems = new ObservableCollection<FaqItem>(
                    allFaqItems.Where(f => f.Category == SelectedCategory));
            }
        }
    }

    // FAQ item model
    public class FaqItem
    {
        public string? Question { get; set; }
		public string? Answer { get; set; }
		public string? Category { get; set; }
		public DateTime Date { get; set; }
	}

}
