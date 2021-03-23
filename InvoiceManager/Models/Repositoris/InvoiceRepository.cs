using InvoiceManager.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace InvoiceManager.Models.Repositoris
{
    public class InvoiceRepository
    {
        public List<MethodOfPaymand> GetMethodOfPaymend()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.MethodOfPaymands.ToList();
            }
        }

        public List<Invoice> GetInvoives(string userId)
        {
            using(var context = new ApplicationDbContext())
            {
                return context.Invoices.Include(x => x.Client).Where(x => x.UserId == userId).ToList();
            }
        }

        public Invoice GetInvoive(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Invoices
                    .Include(x => x.InvoicePositions)
                    .Include(x => x.InvoicePositions.Select(y => y.Product))
                    .Include(x => x.MethodOfPaymand)
                    .Include(x => x.User)
                    .Include(x => x.User.Address)
                    .Include(x => x.Client)
                    .Include(x => x.Client.Address)
                    .Single(x => x.Id == id && x.UserId == userId);
            }
        }

        public InvoicePosition GetInvoicePosition(int invoicePositionId, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.InvoicePositions
                    .Include(x => x.Invoice)
                    .Single(x => x.Id == invoicePositionId && x.Invoice.UserId == userId);
            }
        }

        public void Add(Invoice invoice)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Invoices.Add(invoice);
                context.SaveChanges();
            }
        }

        public void Update(Invoice invoice)
        {
            using (var context = new ApplicationDbContext())
            {
                var invoiceToUpdate = context.Invoices
                    .Single(x => x.Id == invoice.Id && x.UserId == invoice.UserId);

                invoiceToUpdate.ClientId = invoice.ClientId;
                invoiceToUpdate.Comments = invoice.Comments;
                invoiceToUpdate.MethodOfPaymand = invoice.MethodOfPaymand;
                invoiceToUpdate.PaymandDate = invoice.PaymandDate;
                invoiceToUpdate.Title = invoice.Title;

                context.SaveChanges();
            }
        }

        public void AddPosition(InvoicePosition invoicePosition, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var invoice = context.Invoices.Single(x => 
                x.Id == invoicePosition.InvoiceId && 
                x.UserId == userId);

                context.InvoicePositions.Add(invoicePosition);
                context.SaveChanges();
            }
        }

        public void UpdatePosition(InvoicePosition invoicePosition, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var positionToUpdate = 
            }
        }

        public Decimal UpdateInvoiceValue(int invoiceId, string userId)
        {
            using (var context = new ApplicationDbContext())
            {

            }
        }

        public void Delete(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {

            }
        }

        public void DeletePosition(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {

            }
        }
    }
}