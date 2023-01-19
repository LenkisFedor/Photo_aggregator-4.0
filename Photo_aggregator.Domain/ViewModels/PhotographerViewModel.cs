using Photo_aggregator.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_aggregator.Domain.ViewModels
{
	public class PhotographerViewModel
	{
		public int PhotographerId { get; set; }
		public string PhotographerName { get; set; } = null!;
		public string? PhotographerSurname { get; set; }
		public string? PhotographerEmail { get; set; }
		public short? PhotographerWorkExperience { get; set; }

		public virtual ICollection<Publication> Publications { get; set; }
		public virtual ICollection<Request> Requests { get; set; }
		public virtual ICollection<Review> Reviews { get; set; }
	}
}
