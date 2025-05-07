using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Appointment
{
    public int Id { get; set; }
    
    public DateTime Date { get; set; }

    public int Hour { get; set; }

    public int DoctorId { get; set; }

    public string? ClientId { get; set; }
}
