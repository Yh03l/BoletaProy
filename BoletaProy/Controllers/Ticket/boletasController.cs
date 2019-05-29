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
    public class boletasController : Controller
    {
        private dbProyBoletaEntities db = new dbProyBoletaEntities();

        // GET: boletas
        public ActionResult Index()
        {
            var boleta = db.boleta.Include(b => b.persona).Include(b => b.servicio).Include(b => b.usuario);
            return View(boleta.ToList());
        }

        // GET: boletas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boleta boleta = db.boleta.Find(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // GET: boletas/Create
        public ActionResult Create()
        {
            ViewBag.id_pers = new SelectList(db.persona, "id", "nombre");
            ViewBag.id_serv = new SelectList(db.servicio, "id", "nombre");
            ViewBag.id_usr = new SelectList(db.usuario, "id", "nombre_usuario");
            return View();
        }

        // POST: boletas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nro_orden,descripcion,estado,fecha_inicio,fecha_asignacion,fecha_fin,hora_inicio,hora_asignacion,hora_fin,prioridad,id_usr,id_pers,id_serv")] boleta boleta)
        {
            if (ModelState.IsValid)
            {
                db.boleta.Add(boleta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_pers = new SelectList(db.persona, "id", "nombre", boleta.id_pers);
            ViewBag.id_serv = new SelectList(db.servicio, "id", "nombre", boleta.id_serv);
            ViewBag.id_usr = new SelectList(db.usuario, "id", "nombre_usuario", boleta.id_usr);
            return View(boleta);
        }

        // GET: boletas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boleta boleta = db.boleta.Find(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pers = new SelectList(db.persona, "id", "nombre", boleta.id_pers);
            ViewBag.id_serv = new SelectList(db.servicio, "id", "nombre", boleta.id_serv);
            ViewBag.id_usr = new SelectList(db.usuario, "id", "nombre_usuario", boleta.id_usr);
            return View(boleta);
        }

        // POST: boletas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nro_orden,descripcion,estado,fecha_inicio,fecha_asignacion,fecha_fin,hora_inicio,hora_asignacion,hora_fin,prioridad,id_usr,id_pers,id_serv")] boleta boleta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boleta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_pers = new SelectList(db.persona, "id", "nombre", boleta.id_pers);
            ViewBag.id_serv = new SelectList(db.servicio, "id", "nombre", boleta.id_serv);
            ViewBag.id_usr = new SelectList(db.usuario, "id", "nombre_usuario", boleta.id_usr);
            return View(boleta);
        }

        // GET: boletas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            boleta boleta = db.boleta.Find(id);
            if (boleta == null)
            {
                return HttpNotFound();
            }
            return View(boleta);
        }

        // POST: boletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            boleta boleta = db.boleta.Find(id);
            db.boleta.Remove(boleta);
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
