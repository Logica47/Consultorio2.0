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
    public class recetasController : Controller
    {
        private hospitalEntities db = new hospitalEntities();

        // GET: recetas
        public ActionResult Index()
        {
            var receta = db.receta.Include(r => r.empleado).Include(r => r.paciente);
            return View(receta.ToList());
        }

        // GET: recetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receta receta = db.receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        // GET: recetas/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre");
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre");
            return View();
        }

        // POST: recetas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idReceta,idPaciente,idEmpleado,fechaReceta,detalleReceta")] receta receta)
        {
            if (ModelState.IsValid)
            {
                db.receta.Add(receta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", receta.idEmpleado);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", receta.idPaciente);
            return View(receta);
        }

        // GET: recetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receta receta = db.receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", receta.idEmpleado);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", receta.idPaciente);
            return View(receta);
        }

        // POST: recetas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idReceta,idPaciente,idEmpleado,fechaReceta,detalleReceta")] receta receta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", receta.idEmpleado);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", receta.idPaciente);
            return View(receta);
        }

        // GET: recetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            receta receta = db.receta.Find(id);
            if (receta == null)
            {
                return HttpNotFound();
            }
            return View(receta);
        }

        // POST: recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            receta receta = db.receta.Find(id);
            db.receta.Remove(receta);
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
