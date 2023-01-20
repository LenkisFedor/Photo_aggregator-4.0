using System;
using System.Collections.Generic;

namespace Photo_aggregator
{
    public partial class Publication
    {
        public int PublicationId { get; set; }
        public int AuthorId { get; set; }
        public string? PublicationsSource { get; set; }
        public DateOnly? PublicationDate { get; set; }

        public virtual Photographer Author { get; set; } = null!;
    }
}
