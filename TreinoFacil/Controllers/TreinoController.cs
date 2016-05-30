using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreinoFacil.Models;

namespace TreinoFacil.Controllers
{
    public class TreinoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Treino
        public ViewResult Index(string Busca)
        {
            var treino = from t in db.Treinoes
                         select t;

            if (!String.IsNullOrEmpty(Busca))
            {
                treino = treino.Where(s => s.NomeTreino.Contains(Busca));
            }
            return View(treino.ToList());
        }

        // GET: Treino/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treinoes.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            return View(treino);
        }

        // GET: Treino/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AlunoID = new SelectList(db.Alunoes, "AlunoID", "PrimeiroNome");
            ViewBag.ProfessorID = new SelectList(db.Professors, "ProfessorID", "PrimeiroNome");
            return View();
        }

        // POST: Treino/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "TreinoID,NomeTreino,TipoTreino,Status,FrequenciaSemanal,AlunoID,ProfessorID")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                db.Treinoes.Add(treino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoID = new SelectList(db.Alunoes, "AlunoID", "PrimeiroNome", treino.AlunoID);
            ViewBag.ProfessorID = new SelectList(db.Professors, "ProfessorID", "PrimeiroNome", treino.ProfessorID);
            return View(treino);
        }

        // GET: Treino/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treinoes.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoID = new SelectList(db.Alunoes, "AlunoID", "PrimeiroNome", treino.AlunoID);
            ViewBag.ProfessorID = new SelectList(db.Professors, "ProfessorID", "PrimeiroNome", treino.ProfessorID);
            return View(treino);
        }

        // POST: Treino/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "TreinoID,NomeTreino,TipoTreino,Status,FrequenciaSemanal,AlunoID,ProfessorID")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoID = new SelectList(db.Alunoes, "AlunoID", "PrimeiroNome", treino.AlunoID);
            ViewBag.ProfessorID = new SelectList(db.Professors, "ProfessorID", "PrimeiroNome", treino.ProfessorID);
            return View(treino);
        }

        // GET: Treino/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Treino treino = db.Treinoes.Find(id);
            if (treino == null)
            {
                return HttpNotFound();
            }
            return View(treino);
        }

        // POST: Treino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Treino treino = db.Treinoes.Find(id);
            db.Treinoes.Remove(treino);
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
