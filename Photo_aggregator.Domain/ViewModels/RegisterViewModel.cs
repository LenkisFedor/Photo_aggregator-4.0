using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_aggregator.Domain.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Укажите имя")]
	
		public string Login { get; set; }

	
		[Required(ErrorMessage = "Укажите пароль")]
		[MinLength(6, ErrorMessage = "Пароль должен иметь длину больше 6 символов")]
		public string Password { get; set; }

		public string Email { get; set; }
		public string PhoneNumber { get; set; }	
	}
}
