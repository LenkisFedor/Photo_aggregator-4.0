using Microsoft.AspNetCore.Cors.Infrastructure;
using Photo_aggregator.DAL.Interfaces;
using Photo_aggregator.DAL;
using Photo_aggregator.Service.Interfaces;
using Photo_aggregator.DAL.Repositories;
using Photo_aggregator.Service.Implementations;

namespace Photo_aggregator
{
	public static class Initializer
	{
		public static void InitializeRepositories(this IServiceCollection services)
		{
			services.AddScoped<IBaseRepository<Photographer>, PhotographerRepository>();
            services.AddScoped<IBaseRepository<User>, UserRepository>();
        }

		public static void InitializeServices(this IServiceCollection services)
		{
			services.AddScoped<IPhotographerService, PhotographerService>();
            services.AddScoped<IAccountService, AccountService>();
        }
	}
}
