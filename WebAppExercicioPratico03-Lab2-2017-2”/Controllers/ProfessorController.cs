using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppExercicioPratico03_Lab2_2017_2_.Models;

namespace WebAppExercicioPratico03_Lab2_2017_2_.Controllers
{
    public class ProfessorController : Controller
    {
        private SistemaAcademicoContext db = new SistemaAcademicoContext();

        // GET: Professor
        public ActionResult Index()
        {
            var professor = db.Professor.Include(p => p.NivelEnsino);
            return View(professor.ToList());
        }

        // GET: Professor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professor.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            ViewBag.NivelEnsinoId = new SelectList(db.NivelEnsino, "NivelEnsinoId", "Descricao");
            return View();
        }

        // POST: Professor/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessorId,ProfessorNome,tipoProfessor,NivelEnsinoId")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professor.Add(professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NivelEnsinoId = new SelectList(db.NivelEnsino, "NivelEnsinoId", "Descricao", professor.NivelEnsinoId);
            return View(professor);
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professor.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.NivelEnsinoId = new SelectList(db.NivelEnsino, "NivelEnsinoId", "Descricao", professor.NivelEnsinoId);
            return View(professor);
        }

        // POST: Professor/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessorId,ProfessorNome,tipoProfessor,NivelEnsinoId")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NivelEnsinoId = new SelectList(db.NivelEnsino, "NivelEnsinoId", "Descricao", professor.NivelEnsinoId);
            return View(professor);
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professor.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.Professor.Find(id);
            db.Professor.Remove(professor);
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
