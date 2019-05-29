using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoletaProy.Models;

namespace BoletaProy.Controllers.Ticket
{
    public class solucionsController : Controller
    {
        private dbProyBoletaEntities db = new dbProyBoletaEntities();

        // GET: solucions
        public ActionResult Index()
        {
            var solucion = db.solucion.Include(s => s.boleta);
            return View(solucion.ToList());
        }

        // GET: solucions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            solucion solucion = db.solucion.Find(id);
            if (solucion == null)
            {
                return HttpNotFound();
            }
            return View(solucion);
        }

        // GET: solucions/Create
        public ActionResult Create()
        {
            ViewBag.id_boleta = new SelectList(db.boleta, "id", "descripcion");
            return View();
        }

        // POST: solucions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descripcion,id_boleta")] solucion solucion)
        {
            if (ModelState.IsValid)
            {
                db.solucion.Add(solucion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_boleta = new SelectList(db.boleta, "id", "descripcion", solucion.id_boleta);
            return View(solucion);
        }

        // GET: solucions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            solucion solucion = db.solucion.Find(id);
            if (solucion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_boleta = new SelectList(db.boleta, "id", "descripcion", solucion.id_boleta);
            return View(solucion);
        }

        // POST: solucions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descripcion,id_boleta")] solucion solucion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(solucion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_boleta = new SelectList(db.boleta, "id", "descripcion", solucion.id_boleta);
            return View(solucion);
        }

        // GET: solucions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            solucion solucion = db.solucion.Find(id);
            if (solucion == null)
            {
                return HttpNotFound();
            }
            return View(solucion);
        }

        // POST: solucions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            solucion solucion = db.solucion.Find(id);
            db.solucion.Remove(solucion);
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
