using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services;

public class ClientService : Iclient
{
    DatabaseManager db;
    public ClientService(DatabaseManager db)
    {
        this.db = db;
    }

    public void Create(Client item)
    {

        db.Add(item);
        db.SaveChanges();
    }

    public void Delete(Client item)
    {

        db.Clients.Remove(item);
        db.SaveChanges();
    }

    public List<Client> Read()
    {
        return db.Clients.ToList();
    }

    public bool IsCylinder(Client c)
    {
        if (c.Cylinder > 1.1) return true;
        return false;
    }

    public void UpDate(Client item)
    {
        Client e = db.Clients.FirstOrDefault(e => e.Id == item.Id);
        if (e == null) return;
        e.Id = item.Id;
        e.LeftEyeNumber = item.LeftEyeNumber;
        e.PhoneNumber = item.PhoneNumber;
        e.RightEyeNumber = item.RightEyeNumber;
        e.AddressId = item.AddressId;
        e.Age = item.Age;
        e.Email = item.Email;
        e.Cylinder = item.Cylinder;
        db.SaveChanges(true);

    }



}