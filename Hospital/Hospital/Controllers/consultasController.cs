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
    public class consultasController : Controller
    {
        private hospitalEntities db = new hospitalEntities();

        // GET: consultas
        public ActionResult Index()
        {
            var consulta = db.consulta.Include(c => c.empleado).Include(c => c.paciente);
            return View(consulta.ToList());
        }

        // GET: consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consulta consulta = db.consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: consultas/Create
        public ActionResult Create()
           
        {
            
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre");
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre");
            return View();
        }

        // POST: consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idConsulta,idEmpleado,idPaciente,fecha,costo,motivo")] consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.consulta.Add(consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", consulta.idEmpleado);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", consulta.idPaciente);
            return View(consulta);
        }

        // GET: consultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consulta consulta = db.consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", consulta.idEmpleado);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", consulta.idPaciente);
            return View(consulta);
        }

        // POST: consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idConsulta,idEmpleado,idPaciente,fecha,costo,motivo")] consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.empleado, "idEmpleado", "nombre", consulta.idEmpleado);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", consulta.idPaciente);
            return View(consulta);
        }

        // GET: consultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consulta consulta = db.consulta.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            consulta consulta = db.consulta.Find(id);
            db.consulta.Remove(consulta);
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
