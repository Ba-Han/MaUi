using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaUiApp_Learning.ViewModels
{
	public class ResetPasswordViewModel
	{
		private string? _email;

		public string Email
		{
			get { return _email ?? string.Empty; }
			set
			{
				_email = value;
				OnPropertyChanged(nameof(Email));
			}
		}

		private void OnPropertyChanged(string propertyName)
		{
			throw new NotImplementedException();
		}
	}
}
