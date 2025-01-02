using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcassesment.Models;

namespace mvcassesment.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        northwindEntities north = new northwindEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomersInGermany()
        {
            var customersInGermany = north.Customers
    .Where(c => c.Country == "Germany").ToList();
            return View(customersInGermany);
        }
        public ActionResult CustomerDetailsByOrder()
        {
            var customerorder = north.Orders.Where(o => o.OrderID == 10248).Select(o => o.Customer).FirstOrDefault();
            return View(customerorder);
        }
    }
}