using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreinoFacil.Models;
using PagedList;

namespace TreinoFacil.Controllers
{
    public class AlunoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Aluno
        public ViewResult Index(string sortOrder, string currentFilter, string Busca, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (Busca != null)
            {
                page = 1;
            }
            else
            {
                Busca = currentFilter;
            }

            ViewBag.CurrentFilter = Busca;


            var aluno = from a in db.Alunoes
                        select a;
            

            if (!String.IsNullOrEmpty(Busca))
            {
                aluno = aluno.Where(s => s.UltimoNome.Contains(Busca)
                                       || s.PrimeiroNome.Contains(Busca));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    aluno = aluno.OrderByDescending(s => s.UltimoNome);
                    break;
                case "Date":
                    aluno = aluno.OrderBy(s => s.DataInicioTreino);
                    break;
                case "date_desc":
                    aluno = aluno.OrderByDescending(s => s.DataInicioTreino);
                    break;
                default:
                    aluno = aluno.OrderBy(s => s.UltimoNome);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(aluno.ToPagedList(pageNumber, pageSize));
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Aluno/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "AlunoID,PrimeiroNome,UltimoNome,Email,Login,Senha,Endereco,DataInicioTreino,DataFimTreino")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunoes.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        // GET: Aluno/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "AlunoID,PrimeiroNome,UltimoNome,Email,Login,Senha,Endereco,DataInicioTreino,DataFimTreino")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aluno);
        }

        // GET: Aluno/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunoes.Find(id);
            db.Alunoes.Remove(aluno);
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
