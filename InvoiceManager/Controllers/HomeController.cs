using InvoiceManager.Models.Domains;
using InvoiceManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Invoice(int id = 0)
        {
            EditInvoiceViewModel vm = null;
            if (id == 0)
            {
                vm = new EditInvoiceViewModel
                {
                    Clients = new List<Client> { new Client { Id = 1, Name = "klient 1" } },
                    MethodOfPaymands = new List<MethodOfPaymand> { new MethodOfPaymand { Id = 1, Name = "Przelew" } },
                    Heading = "Edycja Faktury",
                    Invoice = new Invoice()
                };
            }
            else
            {
                vm = new EditInvoiceViewModel
                {
                    Clients = new List<Client> { new Client { Id = 1, Name = "klient 1" } },
                    MethodOfPaymands = new List<MethodOfPaymand> { new MethodOfPaymand { Id = 1, Name = "Przelew" } },
                    Heading = "Edycja Faktury",
                    Invoice = new Invoice
                    {
                        ClientId = 1,
                        Comments = "Siema",
                        CreatedDate = DateTime.Now,
                        PaymandDate = DateTime.Now,
                        MethodOfPaymandId = 1,
                        Id = 1,
                        Value = 100,
                        Title = "FA/00/2000",
                        InvoicePositions = new List<InvoicePosition>
                        { 
                            new InvoicePosition
                            {
                                Id = 1,
                                Lp = 1,
                                Product = new Product { Name = "produkt 1"},
                                Quantity = 2,
                                Value = 50
                            },
                            new InvoicePosition
                            {
                                Id = 2,
                                Lp = 2,
                                Product = new Product { Name = "produkt 2"},
                                Quantity = 3,
                                Value = 80
                            }
                        }

                        

                    }
                };
            }
            
            
            return View(vm);
        }
        public ActionResult Index()
        {
            var invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = 1,
                    Title = "F/00/0001",
                    CreatedDate = DateTime.Now,
                    PaymandDate = DateTime.Now,
                    Value = 100,
                    Client = new Client { Name = "Klient 1" }
                },
                new Invoice
                {
                    Id = 2,
                    Title = "F/00/0002",
                    CreatedDate = DateTime.Now,
                    PaymandDate = DateTime.Now,
                    Value = 150,
                    Client = new Client { Name = "Klient 2" }
                }
            };
            return View(invoices);
        }
        public ActionResult InvoicePositon
            (int invoiceId, int invoicePositionId = 0)
        {
            EditInvoicePositionViewModel vm = null;

            if(invoicePositionId == 0)
            {
                vm = new EditInvoicePositionViewModel
                {
                    InvoicePosition = new InvoicePosition(),
                    Heading = "Dodawanie nowej pozycji",
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = 1,
                            Name = "produkt1"
                        }
                    }
                };
            }
            else 
            {
                vm = new EditInvoicePositionViewModel
                {
                    InvoicePosition = new InvoicePosition
                    {
                        Lp = 1,
                        Value = 100,
                        Quantity = 2,
                        ProductId = 1
                    },
                    Heading = "Edytowanie pozycji",
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = 1,
                            Name = "produkt1"
                        }
                    }
                };
            }
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}