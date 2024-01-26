using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LBMS_Project.Models;

namespace LBMS_Project.Controllers
{
    public class ReturnBooksController : Controller
    {
        private LBMS_T323Entities db = new LBMS_T323Entities();

        // GET: ReturnBooks
        public ActionResult Index()
        {
            return View(db.ReturnBooks.ToList());
        }

        // GET: ReturnBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnBook returnBook = db.ReturnBooks.Find(id);
            if (returnBook == null)
            {
                return HttpNotFound();
            }
            return View(returnBook);
        }

        // GET: ReturnBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReturnBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Title,Publication,AuthorName,ISBN,BorrowDate,ReturnDate")] ReturnBook returnBook)
        {
            if (ModelState.IsValid)
            {
                db.ReturnBooks.Add(returnBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(returnBook);
        }

        // GET: ReturnBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnBook returnBook = db.ReturnBooks.Find(id);
            if (returnBook == null)
            {
                return HttpNotFound();
            }
            return View(returnBook);
        }

        // POST: ReturnBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Title,Publication,AuthorName,ISBN,BorrowDate,ReturnDate")] ReturnBook returnBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returnBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(returnBook);
        }

        // GET: ReturnBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnBook returnBook = db.ReturnBooks.Find(id);
            if (returnBook == null)
            {
                return HttpNotFound();
            }
            return View(returnBook);
        }

        // POST: ReturnBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReturnBook returnBook = db.ReturnBooks.Find(id);
            db.ReturnBooks.Remove(returnBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
