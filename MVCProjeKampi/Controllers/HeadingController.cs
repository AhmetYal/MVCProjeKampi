using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            var Headingvalues = hm.GetList();
            return View(Headingvalues);
        }
        public ActionResult HeadingReport()
        {
            var Headingvalues = hm.GetList();
            return View(Headingvalues);
        }


        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecatagory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList() ;
            ViewBag.vlc = valuecatagory;
            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " + x.WriterSurName,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {

            //ValidationResult results = writerValidator.Validate(p);
            //if (results.IsValid)
            //{
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                hm.HeadingAdd(p);
                return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();
        }
        public ActionResult DeleteHeading(int id)
        {            
                var headingValue = hm.GetByID(id);
                _ = headingValue.HeadingStatus == false ? headingValue.HeadingStatus = true
                    : headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
                return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecatagory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            var Headingvalues = hm.GetByID(id);
            ViewBag.vlc = valuecatagory;
            return View(Headingvalues);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            //ValidationResult results = writerValidator.Validate(p);
            //if (results.IsValid)
            //{
            //    hm.WriterUpdate(p);
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
    }

}