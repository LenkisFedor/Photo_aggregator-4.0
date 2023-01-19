using Microsoft.EntityFrameworkCore;
using Photo_aggregator.DAL;
using Photo_aggregator.DAL.Interfaces;
using Photo_aggregator.Domain.Enum;
using Photo_aggregator.Domain.Response;
using Photo_aggregator.Domain.ViewModels;
using Photo_aggregator.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Photo_aggregator.Service.Implementations
{
	public class PhotographerService : IPhotographerService
	{
		private readonly IBaseRepository<Photographer> _photographerRepository;

		public PhotographerService(IBaseRepository<Photographer> photographerRepository)
		{
			_photographerRepository = photographerRepository;
		}
		public async Task<IBaseResponse<Photographer>> Create(PhotographerViewModel model)
		{
			try
			{
				var photographer = new Photographer()
				{
					PhotographerId = model.PhotographerId,
					PhotographerName = model.PhotographerName,
					PhotographerSurname = model.PhotographerSurname,
					PhotographerWorkExperience = model.PhotographerWorkExperience,
					PhotographerEmail = model.PhotographerEmail,
					Publications= model.Publications,
					Requests= model.Requests,
					Reviews= model.Reviews
				};
				await _photographerRepository.Create(photographer);

				return new BaseResponse<Photographer>()
				{
					StatusCode = StatusCode.OK,
					Data = photographer
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<Photographer>()
				{
					Description = $"[Create] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<bool>> DeletePhotographer(int id)
		{
			try
			{
				var photographer = await _photographerRepository.GetAll().FirstOrDefaultAsync(x => x.PhotographerId == id);
				if (photographer == null)
				{
					return new BaseResponse<bool>()
					{
						Description = "User not found",
						StatusCode = StatusCode.UserNotFound,
						Data = false
					};
				}

				await _photographerRepository.Delete(photographer);

				return new BaseResponse<bool>()
				{
					Data = true,
					StatusCode = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool>()
				{
					Description = $"[DeletePhotographer] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<Photographer>> Edit(int id, PhotographerViewModel model)
		{
			try
			{
				var photographer = await _photographerRepository.GetAll().FirstOrDefaultAsync(x => x.PhotographerId == id);
				if (photographer == null)
				{
					return new BaseResponse<Photographer>()
					{
						Description = "Photographer not found",
						StatusCode = StatusCode.PhotographerNotFound
					};
				}

				photographer.PhotographerId = model.PhotographerId;
				photographer.PhotographerName = model.PhotographerName;
				photographer.PhotographerSurname = model.PhotographerSurname;
				photographer.PhotographerWorkExperience = model.PhotographerWorkExperience;
				photographer.PhotographerEmail = model.PhotographerEmail;
				photographer.Publications = model.Publications;
				photographer.Requests = model.Requests;
				photographer.Reviews = model.Reviews;

				await _photographerRepository.Update(photographer);


				return new BaseResponse<Photographer>()
				{
					Data = photographer,
					StatusCode = StatusCode.OK,
				};
				// TypePhotographer
			}
			catch (Exception ex)
			{
				return new BaseResponse<Photographer>()
				{
					Description = $"[Edit] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public IBaseResponse<List<Photographer>> GetPhotographers()
		{
			try
			{
				var photographers = _photographerRepository.GetAll().ToList();
				if (!photographers.Any())
				{
					return new BaseResponse<List<Photographer>>()
					{
						Description = "Найдено 0 элементов",
						StatusCode = StatusCode.OK
					};
				}

				return new BaseResponse<List<Photographer>>()
				{
					Data = photographers,
					StatusCode = StatusCode.OK
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<Photographer>>()
				{
					Description = $"[GetPhotographers] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<IBaseResponse<PhotographerViewModel>> GetPhotographer(int id)
		{
			try
			{
				var photographer = await _photographerRepository.GetAll().FirstOrDefaultAsync(x => x.PhotographerId == id);
				if (photographer == null)
				{
					return new BaseResponse<PhotographerViewModel>()
					{
						Description = "Пользователь не найден",
						StatusCode = StatusCode.UserNotFound
					};
				}

				var data = new PhotographerViewModel()
				{
					PhotographerId = photographer.PhotographerId,
					PhotographerName = photographer.PhotographerName,
					PhotographerSurname = photographer.PhotographerSurname,
					PhotographerWorkExperience = photographer.PhotographerWorkExperience,
					PhotographerEmail = photographer.PhotographerEmail,
					Publications = photographer.Publications,
					Requests = photographer.Requests,
					Reviews = photographer.Reviews
				};

				return new BaseResponse<PhotographerViewModel>()
				{
					StatusCode = StatusCode.OK,
					Data = data
				};
			}
			catch (Exception ex)
			{
				return new BaseResponse<PhotographerViewModel>()
				{
					Description = $"[GetPhotographer] : {ex.Message}",
					StatusCode = StatusCode.InternalServerError
				};
			}
		}

		public async Task<BaseResponse<Dictionary<int, string>>> GetPhotographer(string term)
		{
			var baseResponse = new BaseResponse<Dictionary<int, string>>();
			try
			{
				var photographers = await _photographerRepository.GetAll()
					.Select(x => new PhotographerViewModel()
					{
						PhotographerId = x.PhotographerId,
						PhotographerName = x.PhotographerName,
						PhotographerSurname = x.PhotographerSurname,
						PhotographerWorkExperience = x.PhotographerWorkExperience,
						PhotographerEmail = x.PhotographerEmail,
						Publications = x.Publications,
						Requests = x.Requests,
						Reviews = x.Reviews
					})
					.Where(x => EF.Functions.Like(x.PhotographerName, $"%{term}%"))
					.ToDictionaryAsync(x => x.PhotographerId, t => t.PhotographerName);

				baseResponse.Data = photographers;
				return baseResponse;
			}
			catch (Exception ex)
			{
				return new BaseResponse<Dictionary<int, string>>()
				{
					Description = ex.Message,
					StatusCode = StatusCode.InternalServerError
				};
			}
		}
	}
}
