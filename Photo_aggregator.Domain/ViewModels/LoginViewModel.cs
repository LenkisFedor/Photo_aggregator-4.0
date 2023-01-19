using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Photo_aggregator.Domain.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Введите имя")]

		private string _password;

		public string Login { get; set; }


		[Required(ErrorMessage = "Введите пароль")]
		//[DataType(DataType.Password)]
		//[Display(Name = "Пароль")]
		public string Password 
		
		{ 
			get { return _password; }
			set { _password = value; }
		}
    }
}
