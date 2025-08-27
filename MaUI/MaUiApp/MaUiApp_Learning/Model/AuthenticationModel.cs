using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaUiApp_Learning.Model
{
	public class AuthenticationModel
	{
		public class LoginModel
		{
			public string? Email { get; set; }

			public string? Password { get; set; }
			public bool Remember_me { get; set; }
		}
	}
}
