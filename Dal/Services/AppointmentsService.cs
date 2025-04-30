using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services;

public class AppointmentsService : IApointment
{
    DatabaseManager db;
    public AppointmentsService(DatabaseManager db)
    {
        this.db = db;
    }

    public void Create(Appointment item)
    {
        db.Add(item);
        db.SaveChanges();
    }

    public void Delete(Appointment item)
    {
        db.Appointments.Remove(item);
        db.SaveChanges();
    }

    public List<Appointment> Read()
    {
        return db.Appointments.ToList();
    }



    public void UpDate(Appointment item)
    {
        Appointment e = db.Appointments.FirstOrDefault(e => e.Id == item.Id);
        if (e == null) return;
        e.Id = item.Id;
        e.Date = item.Date;
        e.Hour = item.Hour;
        e.DoctorId = item.DoctorId;
        e.ClientId = item.ClientId;
        db.SaveChanges(true);

    }

  
}