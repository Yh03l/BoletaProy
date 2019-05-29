using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoletaProy.Models;

namespace BoletaProy.Controllers.Services
{
    public class serviciosController : Controller
    {
        private dbProyBoletaEntities db = new dbProyBoletaEntities();

        // GET: servicios
        public ActionResult Index()
        {
            var servicio = db.servicio.Include(s => s.tipo_servicio);
            return View(servicio.ToList());
        }

        // GET: servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio servicio = db.servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: servicios/Create
        public ActionResult Create()
        {
            ViewBag.tipo_ser = new SelectList(db.tipo_servicio, "id", "nombre");
            return View();
        }

        // POST: servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,tipo_ser,estado")] servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.servicio.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipo_ser = new SelectList(db.tipo_servicio, "id", "nombre", servicio.tipo_ser);
            return View(servicio);
        }

        // GET: servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio servicio = db.servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipo_ser = new SelectList(db.tipo_servicio, "id", "nombre", servicio.tipo_ser);
            return View(servicio);
        }

        // POST: servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,tipo_ser,estado")] servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipo_ser = new SelectList(db.tipo_servicio, "id", "nombre", servicio.tipo_ser);
            return View(servicio);
        }

        // GET: servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            servicio servicio = db.servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            servicio servicio = db.servicio.Find(id);
            db.servicio.Remove(servicio);
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
