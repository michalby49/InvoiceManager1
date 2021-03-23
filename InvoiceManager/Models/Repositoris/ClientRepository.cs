using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Repositoris
{
    public class ClientRepository
    {
        public List<Client> GetClient(string userId)
        {
            using(var context = new ApplicationDbContext()) 
            {
                return context.Clients.Where(x => x.UserId == userId).ToList();
            }
        }
    }
}