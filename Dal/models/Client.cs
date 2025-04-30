using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Client
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int? AddressId { get; set; }

    public int Age { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public double LeftEyeNumber { get; set; }

    public double RightEyeNumber { get; set; }

    public double Cylinder { get; set; }

    public string? Email { get; set; }

    public bool BackgroundDiseases { get; set; }

    public string HealthInsurance { get; set; } = null!;

    public virtual Address? Address { get; set; }
}
