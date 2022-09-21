using DataComponentLib.Models;
using DataComponentLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Customer.ViewModels;

namespace Customer.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            var context = new BookHuntEntities();
            return View(context.BookTables.ToList());
        }

        public ActionResult RegisterNewCustomer()
        {

            CustomerDetails model = new CustomerDetails();
            return View(model);
        }

        [HttpPost]
        public ActionResult RegisterNewCustomer(CustomerDetails cust)
        {
            //Check for the validation. If Valid =>
            if (ModelState.IsValid && IsValidCustomer(cust.CustomerEmailId))
            {
                //Connect to the database
                var context = new BookHuntEntities();
                CustomerTable rec = new CustomerTable
                { CustomerName = cust.CustomerName, CustomerId = cust.CustomerId, CustomerEmailId = cust.CustomerEmailId, CustomerPassword = cust.CustomerPassword,CustomerPhNo = cust.CustomerPhNo };//Convert the ViewModel object to Model object. 
                context.CustomerTables.Add(rec); //Insert the new record
                context.SaveChanges();
                ViewBag.Message = "User Successfully registered with Us!!!";
                //Redirect to the Home Page
                return RedirectToAction("Index");
            }
            else//If the validation fails. 
            {
                ModelState.AddModelError("Failure", "User already Exists");
                return View();
            }
        }

        private bool IsValidCustomer(string emailAddress)
        {
            //Connect to the Database
            var context = new BookHuntEntities();
            //Check for the record matching the email Address
            var rec = context.CustomerTables.FirstOrDefault((cust) => cust.CustomerEmailId == emailAddress);
            //if Exists, return false else return true. 
            if (rec == null) return true;
            return false;
        }

        public ActionResult CustomerLogin()
        {
            var model = new LoginView();
            return View(model);
        }

        [HttpPost]
        public ActionResult CustomerLogin(LoginView loginDetails)
        {
            //Response.Write("<script>alert(loginDetails.CustomerEmailId)</script>");
            ////alert(loginDetails.CustomerEmailId);
            //Response.Write(loginDetails.CustomerPassword);
            if (ModelState.IsValid)
            {
                
                var context = new BookHuntEntities();
                var cust = context.CustomerTables.SingleOrDefault((u) => u.CustomerEmailId == loginDetails.CustomerEmailId && u.CustomerPassword == loginDetails.CustomerPassword);
                if (cust == null)
                {   
                    ModelState.AddModelError("LoginFailure", "Login Failed for the User");
                    return View(loginDetails);
                }
                Session["user"] = loginDetails.CustomerEmailId;
                FormsAuthentication.SetAuthCookie(loginDetails.CustomerEmailId, false);
                FormsAuthentication.RedirectFromLoginPage(loginDetails.CustomerPassword, false);
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");/*Response.Redirect("Index","Index" ,"Account");*/      
        }
        public ActionResult VendorCustomer()
        {
            return View();
        }

        //[HttpGet]
        [Authorize]

        public ActionResult CustomerLogout()
        {
            return View(Session["user"]);
        }

        [HttpPost]
        public ActionResult CustomerLogout(string emailId)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}