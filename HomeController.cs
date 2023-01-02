//Name: Gloria Wang
//Date: 09/23/2022
//Description: HW2 – Bookstore Checkout 

using Microsoft.AspNetCore.Mvc;

// give controllers namespace access to models
using Wang_Gloria_HW2.Models;


namespace Wang_Gloria_HW2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckoutDirect()
        {
            return View();
        }

        public IActionResult DirectTotals(DirectOrder directOrder)
        {
            //validation rules
            TryValidateModel(directOrder);

            //return to page if validation fails
            if (ModelState.IsValid == false)
            {
                ViewBag.Error = "Please make sure you have entered valid data.";
                return View("CheckoutDirect", directOrder);
            }

            //set customer type
            directOrder.CustomerType = CustomerType.Direct;

            //error for no items
            try
            {
                //calculate totals
                directOrder.CalcTotals();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message + " " + ex.InnerException.Message;
                return View("CheckoutDirect", directOrder);
            }

            //display results
            return View(directOrder);
        }

        public IActionResult CheckoutWholesale()
        {
            return View();
        }

        public IActionResult WholesaleTotals(WholesaleOrder wholesaleOrder)
        {
            //validation rules
            TryValidateModel(wholesaleOrder);

            //return to page if validation fails
            if (ModelState.IsValid == false)
            {
                ViewBag.Error = "Please make sure you have entered valid data.";
                return View("CheckoutWholesale", wholesaleOrder);
            }

            //set customer type
            wholesaleOrder.CustomerType = CustomerType.Wholesale;

            //error for no items
            try
            {
                //calculate totals
                wholesaleOrder.CalcTotals();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message + " " + ex.InnerException.Message;
                return View("CheckoutWholesale", wholesaleOrder);
            }

            //display results
            return View(wholesaleOrder);
        }
    }
}
