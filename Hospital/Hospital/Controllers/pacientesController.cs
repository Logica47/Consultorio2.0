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
    public class pacientesController : Controller
    {
        private hospitalEntities db = new hospitalEntities();

        // GET: pacientes
        public ActionResult Index()
        {
            var paciente = db.paciente.Include(p => p.tipoSangre1);
            return View(paciente.ToList());
        }

        // GET: pacientes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: pacientes/Create
        public ActionResult Create()
        {
            ViewBag.tipoSangre = new SelectList(db.tipoSangre, "idSangre", "tipo");
            return View();
        }

        // POST: pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cedula,nombre,apellido,fechaNacimiento,tipoSangre,telefono")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.paciente.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipoSangre = new SelectList(db.tipoSangre, "idSangre", "tipo", paciente.tipoSangre);
            return View(paciente);
        }

        // GET: pacientes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoSangre = new SelectList(db.tipoSangre, "idSangre", "tipo", paciente.tipoSangre);
            return View(paciente);
        }

        // POST: pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cedula,nombre,apellido,fechaNacimiento,tipoSangre,telefono")] paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipoSangre = new SelectList(db.tipoSangre, "idSangre", "tipo", paciente.tipoSangre);
            return View(paciente);
        }

        // GET: pacientes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            paciente paciente = db.paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            paciente paciente = db.paciente.Find(id);
            db.paciente.Remove(paciente);
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
