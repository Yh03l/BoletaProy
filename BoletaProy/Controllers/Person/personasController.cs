using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BoletaProy.Models;

namespace BoletaProy.Controllers.Person
{
    public class personasController : Controller
    {
        private dbProyBoletaEntities db = new dbProyBoletaEntities();

        // GET: personas
        public ActionResult Index()
        {
            var persona = db.persona.Include(p => p.area).Include(p => p.tipo_persona).Include(p => p.usuario);
            return View(persona.ToList());
        }

        // GET: personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: personas/Create
        public ActionResult Create()
        {
            ViewBag.id_area = new SelectList(db.area, "id", "nombre");
            ViewBag.tipo_per = new SelectList(db.tipo_persona, "id", "descripcion");
            ViewBag.id = new SelectList(db.usuario, "id", "nombre_usuario");
            return View();
        }

        // POST: personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidop,apellidom,ci,direccion,email,telefono,tipo_per,id_area,sexo,estado")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_area = new SelectList(db.area, "id", "nombre", persona.id_area);
            ViewBag.tipo_per = new SelectList(db.tipo_persona, "id", "descripcion", persona.tipo_per);
            ViewBag.id = new SelectList(db.usuario, "id", "nombre_usuario", persona.id);
            return View(persona);
        }

        // GET: personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_area = new SelectList(db.area, "id", "nombre", persona.id_area);
            ViewBag.tipo_per = new SelectList(db.tipo_persona, "id", "descripcion", persona.tipo_per);
            ViewBag.id = new SelectList(db.usuario, "id", "nombre_usuario", persona.id);
            return View(persona);
        }

        // POST: personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidop,apellidom,ci,direccion,email,telefono,tipo_per,id_area,sexo,estado")] persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_area = new SelectList(db.area, "id", "nombre", persona.id_area);
            ViewBag.tipo_per = new SelectList(db.tipo_persona, "id", "descripcion", persona.tipo_per);
            ViewBag.id = new SelectList(db.usuario, "id", "nombre_usuario", persona.id);
            return View(persona);
        }

        // GET: personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            persona persona = db.persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            persona persona = db.persona.Find(id);
            db.persona.Remove(persona);
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
