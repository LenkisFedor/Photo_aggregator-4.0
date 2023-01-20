using Photo_aggregator.Domain;
using System;
using System.Collections.Generic;

namespace Photo_aggregator
{
    public partial class Request
    {
        public int RequestId { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly ExecutionDate { get; set; }
        public int ServiceTypeId { get; set; }
        public int ClientId { get; set; }
        public int PhotographerId { get; set; }

        public virtual User Client { get; set; } = null!;
        public virtual Photographer Photographer { get; set; } = null!;
        public virtual Service ServiceType { get; set; } = null!;
    }
}
