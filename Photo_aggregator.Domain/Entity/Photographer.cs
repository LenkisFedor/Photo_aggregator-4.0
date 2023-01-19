using System;
using System.Collections.Generic;

namespace Photo_aggregator.DAL
{
    public partial class Photographer
    {
        public Photographer()
        {
            Publications = new List<Publication>();
            Requests = new List<Request>();
            Reviews = new List<Review>();
        }

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
