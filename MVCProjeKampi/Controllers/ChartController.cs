using MVCProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(),JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazılım",
                
            }) ;
            ct.Add(new CategoryClass()
            {
                CategoryName = "Eğitim",
                
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Dizi",
                
            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Film",
                
            });
            return ct;
        }
    }
}