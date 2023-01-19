using System;
using System.Collections.Generic;

namespace Photo_aggregator.DAL
{
    public partial class EmployeePosition
    {
        public EmployeePosition()
        {
            Employees = new HashSet<Employee>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
