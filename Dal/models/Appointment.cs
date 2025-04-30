using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public TimeSpan Hour { get; set; }

    public int DoctorId { get; set; }

    public string? ClientId { get; set; }
}
