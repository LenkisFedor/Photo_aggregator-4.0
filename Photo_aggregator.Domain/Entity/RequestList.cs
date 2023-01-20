using System;
using System.Collections.Generic;

namespace Photo_aggregator
{
    public partial class RequestList
    {
        public int? RequestId { get; set; }
        public DateOnly? CreationDate { get; set; }
        public DateOnly? ExecutionDate { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? ClientId { get; set; }
        public int? PhotographerId { get; set; }
    }
}
