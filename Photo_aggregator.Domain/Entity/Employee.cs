using System;
using System.Collections.Generic;

namespace Photo_aggregator
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public string EmployeeSurname { get; set; } = null!;
        public int EmployeePosition { get; set; }

        public virtual User EmployeeNavigation { get; set; } = null!;
        public virtual EmployeePosition EmployeePositionNavigation { get; set; } = null!;
    }
}
