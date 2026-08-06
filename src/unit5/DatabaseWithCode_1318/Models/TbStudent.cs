using System;
using System.Collections.Generic;

namespace DatabaseWithCode_1318.Models;

public partial class TbStudent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public decimal Salary { get; set; }
}
