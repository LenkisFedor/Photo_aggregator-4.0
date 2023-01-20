using System;
using System.Collections.Generic;

namespace Photo_aggregator
{
    public partial class Review
    {
        public int ReviewId { get; set; }
        public int AuthorId { get; set; }
        public int PhotographerId { get; set; }
        public string? Description { get; set; }

        public virtual Client Author { get; set; } = null!;
        public virtual Photographer Photographer { get; set; } = null!;
    }
}
