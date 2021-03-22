using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InvoiceManager.Models.Domains
{
    public class Invoice
    {
        public Invoice()
        {
            InvoicePositions = new Collection<InvoicePosition>();
        }
        public int Id { get; set; }

        [Required]
        [Display(Name ="Tytuł")]
        public string Title { get; set; }
        
        [Display(Name = "Wartość")]
        public decimal Value { get; set; }

        [Display(Name = "Sposób płatności")]
        public int MethodOfPaymandId { get; set; }

        [Display(Name = "Termin płatności")]
        public DateTime PaymandDate { get; set; }

        [Display(Name = "Data utworzenia")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Komentarz")]
        public string Comments { get; set; }

        [Display(Name = "Klient")]
        public int ClientId { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }


        public MethodOfPaymand MethodOfPaymand { get; set; }
        public Client Client { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<InvoicePosition> InvoicePositions { get; set; }

    }
}