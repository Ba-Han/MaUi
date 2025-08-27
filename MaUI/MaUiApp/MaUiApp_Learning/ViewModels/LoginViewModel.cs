using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaUiApp_Learning.ViewModels
{
	public class LoginViewModel
	{
		private string? _email;
		private string? _password;

		public string Email
		{
			get { return _email ?? string.Empty; }
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
			}
		}

		public string Password
		{
			get { return _password ?? string.Empty; }
			set
			{
				_password = value;
				OnPropertyChanged(nameof(Password));
			}
		}

		protected void OnPropertyChanged(string propertyName)
		{
			throw new NotImplementedException();
		}
	}
}
