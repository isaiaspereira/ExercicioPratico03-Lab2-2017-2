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
    public class EstudanteController : Controller
    {
        private SistemaAcademicoContext db = new SistemaAcademicoContext();

        // GET: Estudante
        public ActionResult Index()
        {
            var estudante = db.Estudante.Include(e => e.Endereco).Include(e => e.NivelEnsino);
            return View(estudante.ToList());
        }

        // GET: Estudante/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudante.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            return View(estudante);
        }

        // GET: Estudante/Create
        public ActionResult Create()
        {
            ViewBag.EstudanteId = new SelectList(db.Endereco, "EnderecoId", "Endereco1");
            ViewBag.NivelEnsinoId = new SelectList(db.NivelEnsino, "NivelEnsinoId", "Descricao");
            return View();
        }

        // POST: Estudante/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstudanteId,NomeEstudante,DataNascimento,Foto,Altura,Peso,NivelEnsinoId")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                db.Estudante.Add(estudante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstudanteId = new SelectList(db.Endereco, "EnderecoId", "Endereco1", estudante.EstudanteId);
            ViewBag.NivelEnsinoId = new SelectList(db.NivelEnsino, "NivelEnsinoId", "Descricao", estudante.NivelEnsinoId);
            return View(estudante);
        }

        // GET: Estudante/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudante.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstudanteId = new SelectList(db.Endereco, "EnderecoId", "Endereco1", estudante.EstudanteId);
            ViewBag.NivelEnsinoId = new SelectList(db.NivelEnsino, "NivelEnsinoId", "Descricao", estudante.NivelEnsinoId);
            return View(estudante);
        }

        // POST: Estudante/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstudanteId,NomeEstudante,DataNascimento,Foto,Altura,Peso,NivelEnsinoId")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstudanteId = new SelectList(db.Endereco, "EnderecoId", "Endereco1", estudante.EstudanteId);
            ViewBag.NivelEnsinoId = new SelectList(db.NivelEnsino, "NivelEnsinoId", "Descricao", estudante.NivelEnsinoId);
            return View(estudante);
        }

        // GET: Estudante/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudante estudante = db.Estudante.Find(id);
            if (estudante == null)
            {
                return HttpNotFound();
            }
            return View(estudante);
        }

        // POST: Estudante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudante estudante = db.Estudante.Find(id);
            db.Estudante.Remove(estudante);
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
