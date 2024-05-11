using System;
using System.Collections.Generic;

namespace DataMover.Model;

public partial class EmployeeDatum
{
    public int EmployeeId { get; set; }

    public string EmployeeFirstName { get; set; } = null!;

    public string EmployeeLastName { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string Role { get; set; } = null!;
}
