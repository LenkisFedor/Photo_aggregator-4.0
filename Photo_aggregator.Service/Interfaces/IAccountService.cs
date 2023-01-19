using Photo_aggregator.Domain.Response;
using Photo_aggregator.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Photo_aggregator.Service.Interfaces
{
	public interface IAccountService
	{
		Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);

		Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
	}
}
