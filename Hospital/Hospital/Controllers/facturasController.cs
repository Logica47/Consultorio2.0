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
    public class facturasController : Controller
    {
        private hospitalEntities db = new hospitalEntities();

        // GET: facturas
        public ActionResult Index()
        {
            var factura = db.factura.Include(f => f.cita).Include(f => f.paciente);
            return View(factura.ToList());
        }

        // GET: facturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: facturas/Create
        public ActionResult Create()
        {
            ViewBag.idCita = new SelectList(db.cita, "idCita", "motivo");
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre");
            return View();
        }

        // POST: facturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFactura,idCita,idPaciente,fecha,costo")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.factura.Add(factura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCita = new SelectList(db.cita, "idCita", "motivo", factura.idCita);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", factura.idPaciente);
            return View(factura);
        }

        // GET: facturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCita = new SelectList(db.cita, "idCita", "motivo", factura.idCita);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", factura.idPaciente);
            return View(factura);
        }

        // POST: facturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFactura,idCita,idPaciente,fecha,costo")] factura factura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(factura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCita = new SelectList(db.cita, "idCita", "motivo", factura.idCita);
            ViewBag.idPaciente = new SelectList(db.paciente, "cedula", "nombre", factura.idPaciente);
            return View(factura);
        }

        // GET: facturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            factura factura = db.factura.Find(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            factura factura = db.factura.Find(id);
            db.factura.Remove(factura);
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
