using Microsoft.Extensions.Logging;
using Photo_aggregator.DAL.Interfaces;
using Photo_aggregator.DAL;
using Photo_aggregator.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Photo_aggregator.Domain.Enum;
using Photo_aggregator.Domain.Response;
using System.Data;
using System.Security.Claims;
using Photo_aggregator.Domain.Helpers;
using Photo_aggregator.Service.Interfaces;
using Npgsql;

namespace Photo_aggregator.Service.Implementations
{
	public class AccountService : IAccountService
	{
		private readonly IBaseRepository<User> _userRepository;
		private readonly ILogger<AccountService> _logger;

		public AccountService(IBaseRepository<User> userRepository, ILogger<AccountService> logger)
		{
			_userRepository = userRepository;
			_logger = logger;
		}

		public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
		{
			try
			{
				var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.UserLogin == model.Login);
				if (user != null)
				{
					return new BaseResponse<ClaimsIdentity>()
					{
						Description = "Пользователь с таким логином уже есть",
					};
				}

				user = new User()
				{
					UserLogin = model.Login,
					UserRole = "client",
					UserPass = model.Password,
				};


				await _userRepository.Create(user);

				var result = Authenticate(user);

				return new BaseResponse<ClaimsIdentity>()
				{
					Data = result,
					Description = "Объект добавился",
					StatusCode = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"[Register]: {ex.Message}");
				return new BaseResponse<ClaimsIdentity>()
				{
					Description = ex.Message,
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
		{
			try
			{
				var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.UserLogin == model.Login);
				if (user == null)
				{
					return new BaseResponse<ClaimsIdentity>()
					{
						Description = "Пользователь не найден"
					};
				}

				if (user.UserPass != model.Password)
				{
					return new BaseResponse<ClaimsIdentity>()
					{
						Description = "Неверный пароль или логин"
					};
				}
				var result = Authenticate(user);

				return new BaseResponse<ClaimsIdentity>()
				{
					Data = result,
					StatusCode = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, $"[Login]: {ex.Message}");
				return new BaseResponse<ClaimsIdentity>()
				{
					Description = ex.Message,
					StatusCode = StatusCode.InternalServerError
				};
			}
		}
		private ClaimsIdentity Authenticate(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserLogin),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.UserRole)
			};
			return new ClaimsIdentity(claims, "ApplicationCookie",
				ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
		}
	}
}
