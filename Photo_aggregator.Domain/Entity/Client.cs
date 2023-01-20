using System;
using System.Collections.Generic;

namespace Photo_aggregator
{
    public partial class Client
    {
        public Client()
        {
            Reviews = new HashSet<Review>();
        }

        public string ClientName { get; set; } = null!;
        public string ClientSurname { get; set; } = null!;
        public long ClientNumber { get; set; }
        public string ClientEmail { get; set; } = null!;
        public int ClientId { get; set; }

        public virtual User ClientNavigation { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
