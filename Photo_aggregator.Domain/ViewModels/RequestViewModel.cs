using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_aggregator.Domain.ViewModels
{
    public class RequestViewModel
    {
        public int RequestId { get; set; }
        public DateOnly CreationDate { get; set; }
        public DateOnly ExecutionDate { get; set; }
        public int ServiceTypeId { get; set; }
        public int CleintId { get; set; }
        public int PhotographerId { get; set; }

        public virtual Client Cleint { get; set; } = null!;
        public virtual Photographer Photographer { get; set; } = null!;
        public virtual Service ServiceType { get; set; } = null!;
    }
}
