using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceManager.Models.Domains
{
    public class MethodOfPaymand
    {
        public MethodOfPaymand()
        {
            Invoices = new Collection<Invoice>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}