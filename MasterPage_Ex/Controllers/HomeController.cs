using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using MasterPage_Ex.Models;

namespace MasterPage_Ex.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            List<ProductTable> all = new List<ProductTable>();
            using (ProductDatabaseEntities dc = new ProductDatabaseEntities())
           
                all = dc.ProductTables.ToList();
           
            return View(all);
        }
       public ActionResult cat(string name)
        {
            List<ProductTable> all2 = new List<ProductTable>();
            using (ProductDatabaseEntities dc = new ProductDatabaseEntities())
            
                all2 = dc.ProductTables.Where(x => x.Type == name).ToList();
                //ViewBag.P = P;
            

            return View(all2);
        }

       
        public ActionResult LogOut()

         {
            Session.Abandon();
            return RedirectToAction("Login", "Home");
         }
        


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Authorize(CustomerTable model)
        {
            ShoppingDatabaseEntities3 db = new ShoppingDatabaseEntities3();
            var User = db.CustomerTables.Where(x => x.Email == model.Email && x.Password == model.Password && x.IsAdmin == "User").FirstOrDefault();
            var Admin = db.CustomerTables.Where(x => x.Email == model.Email && x.Password == model.Password && x.IsAdmin == "Admin").FirstOrDefault();
            if (Admin != null && User == null)
            {
                 Session["LoginType"] ="Admin";
                 return RedirectToAction("Index", "Admin");
                
            }
           
            else if (User != null && Admin == null)
            {
                Session["LoginType"] = "User";
                return RedirectToAction("Index", "User");

                
            }
            else
            {
                return View("Login", model);
            }

               
            

            

           
           
        }

         [AllowAnonymous] 
        public ActionResult Register()
        {
            return View();
        }

        

         [HttpPost]
         public ActionResult SaveRecord(CustomerTable model)
         {
             //try
             //{
             ShoppingDatabaseEntities3 db = new ShoppingDatabaseEntities3();

                 CustomerTable ct = new CustomerTable();

                 ct.Name = model.Name;
                 ct.Phone = model.Phone;
                 ct.Email = model.Email;
                 ct.Password = model.Password;
                 db.CustomerTables.Add(ct);

                 db.SaveChanges();


             //}
             //catch (Exception ex)
             //{
             //    throw ex;
             //}
                 return RedirectToAction("Register");
                
         }


 //        [HttpPost]
 //        [ValidateAntiForgeryToken]
 //        public ActionResult SaveRecord([Bind(Include =
 //"AutoId,FirstName,LastName,Age,Active")] CustomerTable customertable)
 //        {
 //            if (ModelState.IsValid)
 //            {
 //                ShoppingDatabaseEntities1 db = new ShoppingDatabaseEntities1();
 //                CustomerTable ct = new CustomerTable();
 //                db.CustomerTable.Add(customertable);
 //                db.SaveChanges();
 //                return RedirectToAction("Index");
 //            }

 //            return View(customertable);
 //        }




        
       




       
	}
}