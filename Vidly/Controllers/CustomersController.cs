using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //we need a dbcontext
        private ApplicationDbContext _context;
        //we need to initialize this in the constructor

        public CustomersController()
        {
            _context = new ApplicationDbContext(); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else {
                var costumerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                costumerInDb.Name = customer.Name;
                costumerInDb.Birthdate = customer.Birthdate;
                costumerInDb.MembershipTypeId = customer.MembershipTypeId;
                costumerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        public ViewResult Index()
        {//iterating customers with Tolist
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customers =_context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);

        }
       
    }

}
