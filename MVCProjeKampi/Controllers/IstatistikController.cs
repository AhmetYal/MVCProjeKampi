using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Concrete;

namespace MVCProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var deger1 = c.Categories.Count();
            ViewBag.d1 = deger1;

            var coid = c.Categories.Where(x => x.CategoryName == "Yazılım").Select(y => y.CategoryID).FirstOrDefault();
            var deger2 = c.Headings.Where(x=>x.CategoryID== coid).Count();
            ViewBag.d2 = deger2;

            var deger3 = c.Writers.Where(x => x.WriterName.Contains("A")).ToList() ;
            ViewBag.d3 = deger3;

            var deger4 = c.Headings.Sum(x => x.CategoryID) ;
            ViewBag.d4 = deger4;

            var deger5 = c.Categories.Count();
            ViewBag.d5 = deger5;
            return View();
        }
    }
}