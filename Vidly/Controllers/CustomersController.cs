using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
        public ViewResult Index()
        {//iterating customers with Tolist
            var customers = _context.Customers.ToList();

            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customers =_context.Customers.SingleOrDefault(c => c.Id == id);

            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }
       
    }

}
