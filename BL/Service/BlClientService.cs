using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using Dal.Models;
using Dal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Service;

public class BlClientService : IBlClient
{
    private readonly Iclient dalClient;
    private readonly IAddress dalAddress;
    public BlClientService(IDal dal)
    {
        dalClient = dal.client;
        dalAddress= dal.address;
    }

    public void Create(Client item)
    {
        dalClient.Create(item);
    }

    public void Delete(Client item)
    {
        dalClient.Delete(item);
    }

    public List<EmpForPhone> GetPhoneList()
    {
        if (dalClient == null)
            throw new InvalidOperationException("dalClient is not initialized.");

        var data = dalClient.Read();
        if (data == null)
            throw new InvalidOperationException("dalClient.Read() returned null.");

        return data.Select(e => new EmpForPhone()
        {
            Name = e.Name,
            phone = e.PhoneNumber,
        }).ToList();

    }

    public List<Client> Read()
    {
       return dalClient.Read();
    }
  
    public void UpDate(Client item)
    {
        dalClient.UpDate(item);
    }
    //יצרנו כתובת לפי נתוני הלקוח
    //עדכנו ללקוח  addressid לפי מה שחזר מיצירת כתובת
    //יצרנו לקוח
    public string SignUp(Client c, Address address)
    {
        int addressid = dalAddress.Create(address);
        if (addressid <= 0)
        {
            throw new InvalidOperationException("Failed to create address.");
        }
        c.AddressId = addressid;
        if (string.IsNullOrWhiteSpace(c.Id) )
            throw new InvalidOperationException("Client ID must be exactly 10 characters.");

        dalClient.Create(c);
        c= dalClient.Read().FirstOrDefault(client => client.Id.Trim().Equals(c.Id)); // Refresh client from DB
        if (c == null || string.IsNullOrEmpty(c.Id))
        {
            throw new InvalidOperationException("Failed to create client or retrieve client ID.");
        }
        return c.Id;
    }

    public Client? Login(string id)
    {
        var client = dalClient.Read().FirstOrDefault(c => c.Id.Trim().Equals(id));
        return client;
    }
   
    
    
}


