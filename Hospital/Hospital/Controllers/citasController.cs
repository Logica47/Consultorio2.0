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
    public class citasController : Controller
    {
        private hospitalEntities db = new hospitalEntities();

        // GET: citas
        public ActionResult Index()
        {
            var cita = db.cita.Include(c => c.empleado).Include(c => c.paciente);
            return View(cita.ToList());
        }

        // GET: citas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // GET: citas/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre");
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre");
            return View();
        }

        // POST: citas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCita,motivo,idEmpleado,idPaciente,fechaCita")] cita cita)
        {
            if (ModelState.IsValid)
            {
                db.cita.Add(cita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", cita.idEmpleado);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", cita.idPaciente);
            return View(cita);
        }

        // GET: citas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", cita.idEmpleado);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", cita.idPaciente);
            return View(cita);
        }

        // POST: citas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCita,motivo,idEmpleado,idPaciente,fechaCita")] cita cita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", cita.idEmpleado);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", cita.idPaciente);
            return View(cita);
        }

        // GET: citas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cita cita = db.cita.Find(id);
            if (cita == null)
            {
                return HttpNotFound();
            }
            return View(cita);
        }

        // POST: citas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cita cita = db.cita.Find(id);
            db.cita.Remove(cita);
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
