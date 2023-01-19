using System;
using System.Collections.Generic;

namespace Photo_aggregator.DAL
{
    public partial class Service
    {
        public Service()
        {
            Requests = new HashSet<Request>();
        }

        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = null!;
        public string? ServiceDescription { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}
