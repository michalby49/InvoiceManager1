using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Repositoris
{
    public class ProductRepository
    {
        public List<Product> GetProduts()
        {
            using(var context = new ApplicationDbContext())
            {
                return context.Products.ToList();
            }               
        }

        public Product GetProdut(int productId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Single(x => x.Id == productId);
            }
        }
    }
}