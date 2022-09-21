using DataComponentLib.Models;
using DataComponentLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Customer.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            var allBooks = new List<BookTable>();

            return View(allBooks);
        }

        public ActionResult OnAddToCart(BookTable item)
        {
            var cart = new List<BookTable>();//create a new cart...
            if (Session["cart"] != null)//Check if the cart already exists
            {
                cart = Session["cart"] as List<BookTable>;//Get the items of the cart
            }
            cart.Add(item);
            Session["cart"] = cart;//BOX it 
            return RedirectToAction("Index");
        }

        public ActionResult GoToBill()
        {
            var currentUser = Session["CurrentUser"] as CustomerTable;
            var com = new CartComponent();
            com.Customer = currentUser;
            com.GenerateBill();
            return RedirectToAction("Index");
        }
    }
}