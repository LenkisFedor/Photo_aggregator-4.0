using Photo_aggregator.DAL;
using Photo_aggregator.Domain.Response;
using Photo_aggregator.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Photo_aggregator.Service.Interfaces
{
	public interface IPhotographerService
	{
		IBaseResponse<List<Photographer>> GetPhotographers();

		Task<IBaseResponse<PhotographerViewModel>> GetPhotographer(int id);

		Task<BaseResponse<Dictionary<int, string>>> GetPhotographer(string term);

		Task<IBaseResponse<Photographer>> Create(PhotographerViewModel car);

		Task<IBaseResponse<bool>> DeletePhotographer(int id);

		Task<IBaseResponse<Photographer>> Edit(int id, PhotographerViewModel model);
	}
}
