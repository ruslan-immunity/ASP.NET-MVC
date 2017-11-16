using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using First_project.Models;
using System.Data.Entity;
using System.Data;

namespace First_project.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        BookContext db = new BookContext();
        UnitOfWork unitOfWork;

        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var books = unitOfWork.Books.GetAll();
            ViewBag.Books = books;
            return View();
        }

        public ActionResult Edit(int id)
        {
            Book b = unitOfWork.Books.Get(id);
            ViewBag.Id = id;
            ViewBag.Name = b.Name;
            ViewBag.Author = b.Author;
            ViewBag.Price = b.Price;
            if (b == null)
                return HttpNotFound();
            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(Book b)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Books.Update(b);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(b);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Books.Create(b);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(b);
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Books.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}