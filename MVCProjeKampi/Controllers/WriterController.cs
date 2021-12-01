using System;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MVCProjeKampi.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        // GET: Writer
        public ActionResult Index()
        {
            var Writervalues = wm.GetList();
            return View(Writervalues);         
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteWriter(int id)
        {
            var Writervalues = wm.GetByID(id);
            wm.WriterDelete(Writervalues);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var Writervalues = wm.GetByID(id);
            return View(Writervalues);
        }
        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);
            if (results.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
