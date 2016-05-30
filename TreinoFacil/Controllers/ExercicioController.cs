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
    public class ExercicioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Exercicio
        public ViewResult Index(string Busca)
        {
            var exercicio = from t in db.Exercicios
                              select t;

            if (!String.IsNullOrEmpty(Busca))
            {
                exercicio = exercicio.Where(s => s.NomeExercicio.Contains(Busca));
            }
            return View(exercicio.ToList());
        }

        // GET: Exercicio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // GET: Exercicio/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AtividadeID = new SelectList(db.Atividades, "AtividadeID", "NomeAtividade");
            return View();
        }

        // POST: Exercicio/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "ExercicioID,NomeExercicio,Categoria,Intensidade,Carga,QntdRepeticao,Tempo,AtividadeID")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                db.Exercicios.Add(exercicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AtividadeID = new SelectList(db.Atividades, "AtividadeID", "NomeAtividade", exercicio.AtividadeID);
            return View(exercicio);
        }

        // GET: Exercicio/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.AtividadeID = new SelectList(db.Atividades, "AtividadeID", "NomeAtividade", exercicio.AtividadeID);
            return View(exercicio);
        }

        // POST: Exercicio/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "ExercicioID,NomeExercicio,Categoria,Intensidade,Carga,QntdRepeticao,Tempo,AtividadeID")] Exercicio exercicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AtividadeID = new SelectList(db.Atividades, "AtividadeID", "NomeAtividade", exercicio.AtividadeID);
            return View(exercicio);
        }

        // GET: Exercicio/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exercicio exercicio = db.Exercicios.Find(id);
            if (exercicio == null)
            {
                return HttpNotFound();
            }
            return View(exercicio);
        }

        // POST: Exercicio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercicio exercicio = db.Exercicios.Find(id);
            db.Exercicios.Remove(exercicio);
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
