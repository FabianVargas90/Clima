using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Clima.Models;

namespace Clima.Controllers
{
    
    public class climaController : Controller
    {
        private ClimaEntities db = new ClimaEntities();

        [Authorize]
        // GET: clima
        public ActionResult Index()
        {
            return View(db.CLIMA.ToList());
        }
        [Authorize]
        // GET: clima/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIMA Clima = db.CLIMA.Find(id);
            if (Clima == null)
            {
                return HttpNotFound();
            }
            return View(Clima);
        }
        [Authorize]
        // GET: clima/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        // GET: clima/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIMA Clima = db.CLIMA.Find(id);
            if (Clima == null)
            {
                return HttpNotFound();
            }
            return View(Clima);
        }

        // POST: clima/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Nombre,Descripcion,Fecha")] CLIMA Clima)
        {
            if (ModelState.IsValid)
            {
                db.CLIMA.Add(Clima);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Clima);
        }
        // POST: clima/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Nombre,Descripcion,Fecha")] CLIMA Clima)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Clima).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Clima);
        }

        // GET: clima/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIMA Clima = db.CLIMA.Find(id);
            if (Clima == null)
            {
                return HttpNotFound();
            }
            return View(Clima);
        }

        // POST: clima/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIMA Clima = db.CLIMA.Find(id);
            db.CLIMA.Remove(Clima);
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
