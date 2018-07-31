using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PratosController : Controller
    {
        private Context db = new Context();

        // GET: Pratos
        public ActionResult Index()
        {
            var pratos = db.Pratos.Include(p => p.Rest);
            return View(pratos.ToList());
        }

        // GET: Pratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            return View(prato);
        }

        // GET: Pratos/Create
        public ActionResult Create()
        {
            ViewBag.RestID = new SelectList(db.Restaurantes, "RestauranteID", "RestauranteNome");
            return View();
        }

        // POST: Pratos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PratoID,PratoNome,PratoPreco,RestID")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Pratos.Add(prato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RestID = new SelectList(db.Restaurantes, "RestauranteID", "RestauranteNome", prato.RestID);
            return View(prato);
        }

        // GET: Pratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prato prato = db.Pratos.Find(id);
            if (prato == null)
            {
                return HttpNotFound();
            }
            ViewBag.RestID = new SelectList(db.Restaurantes, "RestauranteID", "RestauranteNome", prato.RestID);
            return View(prato);
        }

        // POST: Pratos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PratoID,PratoNome,PratoPreco,RestID")] Prato prato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RestID = new SelectList(db.Restaurantes, "RestauranteID", "RestauranteNome", prato.RestID);
            return View(prato);
        }

        // GET: Pratos/Delete/5
        public ActionResult Delete(int? id)
        {
            Prato prato = db.Pratos.Find(id);
            db.Pratos.Remove(prato);
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
