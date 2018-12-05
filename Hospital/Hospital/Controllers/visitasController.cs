using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class visitasController : Controller
    {
        private hospitalEntities db = new hospitalEntities();

        // GET: visitas
        public ActionResult Index()
        {
            var visita = db.visita.Include(v => v.empleado).Include(v => v.receta);
            return View(visita.ToList());
        }

        // GET: visitas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // GET: visitas/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre");
            ViewBag.idReceta = new SelectList(db.receta, "idReceta", "idPaciente");
            return View();
        }

        // POST: visitas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVisita,idEmpleado,idReceta,fechaLlegada,proximaFecha,motivo,comentario")] visita visita)
        {
            if (ModelState.IsValid)
            {
                db.visita.Add(visita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", visita.idEmpleado);
            ViewBag.idReceta = new SelectList(db.receta, "idReceta", "idPaciente", visita.idReceta);
            return View(visita);
        }

        // GET: visitas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", visita.idEmpleado);
            ViewBag.idReceta = new SelectList(db.receta, "idReceta", "idPaciente", visita.idReceta);
            return View(visita);
        }

        // POST: visitas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVisita,idEmpleado,idReceta,fechaLlegada,proximaFecha,motivo,comentario")] visita visita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", visita.idEmpleado);
            ViewBag.idReceta = new SelectList(db.receta, "idReceta", "idPaciente", visita.idReceta);
            return View(visita);
        }

        // GET: visitas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            visita visita = db.visita.Find(id);
            if (visita == null)
            {
                return HttpNotFound();
            }
            return View(visita);
        }

        // POST: visitas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            visita visita = db.visita.Find(id);
            db.visita.Remove(visita);
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
