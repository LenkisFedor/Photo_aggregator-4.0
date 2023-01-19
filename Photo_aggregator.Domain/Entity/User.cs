using System;
using System.Collections.Generic;

namespace Photo_aggregator.DAL
{
    public partial class User
    {
        public User()
        {
            Requests = new HashSet<Request>();
        }

        public int UserId { get; set; }
        public string UserLogin { get; set; } = null!;
        public string UserPass { get; set; } = null!;
        public string UserRole { get; set; } = null!;

        public virtual Client? Client { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
    }
}
