using Photo_aggregator.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_aggregator.DAL.Repositories
{
	public class PhotographerRepository : IBaseRepository<Photographer>
	{
		private readonly photo_aggrContext _db;

		public PhotographerRepository(photo_aggrContext db)
		{
			_db = db;
		}
		public async Task Create(Photographer entity)
		{
			await _db.Photographers.AddAsync(entity);
			await _db.SaveChangesAsync();
		}

		public async Task Delete(Photographer entity)
		{
			_db.Photographers.Remove(entity);
			await _db.SaveChangesAsync();
		}

		public IQueryable<Photographer> GetAll()
		{
			return _db.Photographers;
		}

		public async Task<Photographer> Update(Photographer entity)
		{
			_db.Photographers.Update(entity);
			await _db.SaveChangesAsync();

			return entity;
		}
	}
}
