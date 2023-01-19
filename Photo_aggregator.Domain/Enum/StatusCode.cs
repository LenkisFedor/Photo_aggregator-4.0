using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_aggregator.Domain.Enum
{
	public enum StatusCode
	{
		UserNotFound = 0,
		UserAlreadyExists = 1,

		PhotographerNotFound = 10,

		RequestNotFound = 20,

		ServiceNotFound = 30,

		PublicatioNotFound = 40,

		EmployeeNotFound = 50,

		ReviewNotFound = 60,

		ClientNotFound = 70,


		OK = 200,
		InternalServerError = 500
	}
}
