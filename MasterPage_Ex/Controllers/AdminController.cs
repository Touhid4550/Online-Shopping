using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MasterPage_Ex.Models;

namespace MasterPage_Ex.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductTable PD)
        {
            ProductDatabaseEntities db = new ProductDatabaseEntities();

            ProductTable pt = new ProductTable();

            pt.ProductName = PD.ProductName;
            pt.Price = PD.Price;
            pt.Brand = PD.Brand;
            pt.Type = PD.Type;
            pt.Details = PD.Details;
            //pt.ImageData = PD.ImageData;


            //byte[] data = new byte[pt.File.ContentLength];
            byte[] data = new byte[PD.File.ContentLength];
            PD.File.InputStream.Read(data, 0, PD.File.ContentLength);
            pt.ImageData = data;
            using (ProductDatabaseEntities dc = new ProductDatabaseEntities())
            {
                dc.ProductTables.Add(pt);
                dc.SaveChanges();
                @ViewBag.Success = "Seccessfully Added!";
            }


            return RedirectToAction("AddProduct");


        }

        public ActionResult ShowProduct()
        {
            return View();
        }
	}
}