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
    [Authorize]
    public class BorrowBooksController : Controller
    {
        private LBMS_T323Entities db = new LBMS_T323Entities();

        // GET: BorrowBooks
        public ActionResult Index()
        {
            return View(db.BorrowBooks.ToList());
        }

        // GET: BorrowBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowBook borrowBook = db.BorrowBooks.Find(id);
            if (borrowBook == null)
            {
                return HttpNotFound();
            }
            return View(borrowBook);
        }

        // GET: BorrowBooks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BorrowBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Title,Publication,AuthorName,ISBN")] BorrowBook borrowBook)
        {
            if (ModelState.IsValid)
            {
                db.BorrowBooks.Add(borrowBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(borrowBook);
        }

        // GET: BorrowBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowBook borrowBook = db.BorrowBooks.Find(id);
            if (borrowBook == null)
            {
                return HttpNotFound();
            }
            return View(borrowBook);
        }

        // POST: BorrowBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Title,Publication,AuthorName,ISBN")] BorrowBook borrowBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrowBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(borrowBook);
        }

        // GET: BorrowBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BorrowBook borrowBook = db.BorrowBooks.Find(id);
            if (borrowBook == null)
            {
                return HttpNotFound();
            }
            return View(borrowBook);
        }

        // POST: BorrowBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BorrowBook borrowBook = db.BorrowBooks.Find(id);
            db.BorrowBooks.Remove(borrowBook);
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
