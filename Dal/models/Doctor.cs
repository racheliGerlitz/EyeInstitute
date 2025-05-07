using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Doctor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AddressId { get; set; }

    public string Specialization { get; set; } = null!;

    public virtual Address Address { get; set; } = null!;
}
