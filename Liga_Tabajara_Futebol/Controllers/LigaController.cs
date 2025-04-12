using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Liga_Tabajara_Futebol.DAL;
using Liga_Tabajara_Futebol.Models;

namespace Liga_Tabajara_Futebol.Controllers
{
    public class LigaController : Controller
    {
        private LigaTabajaraFutebol db = new LigaTabajaraFutebol();

        // GET: Liga
        public ActionResult Index()
        {
            return View(db.Ligas.ToList());
        }

        public ActionResult Home()
        {
            // Obter a liga principal (assumindo que há apenas uma liga no banco de dados)
            var liga = db.Ligas.Include(l => l.Times.Select(t => t.Jogadores))
                               .Include(l => l.Times.Select(t => t.ComissaoTecnica))
                               .FirstOrDefault();

            if (liga == null)
            {
                return HttpNotFound("Liga não encontrada.");
            }

            // Verificar se a liga está apta
            bool ligaApta = Liga.LigaEstaApta(liga.Times.ToList());

            // Criar um ViewModel para passar os dados para a View
            var viewModel = new LigaHomeViewModel
            {
                Apresentacao = "Bem-vindo à Liga Tabajara Futebol!",
                Times = liga.Times.ToList(),
                StatusLiga = ligaApta ? "Apta para iniciar o campeonato" : "Não apta para iniciar o campeonato"
            };

            return View(viewModel);
        }


        // GET: Liga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liga liga = db.Ligas.Find(id);
            if (liga == null)
            {
                return HttpNotFound();
            }
            return View(liga);
        }

        // GET: Liga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Liga/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Status")] Liga liga)
        {
            if (ModelState.IsValid)
            {
                db.Ligas.Add(liga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(liga);
        }

        // GET: Liga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liga liga = db.Ligas.Find(id);
            if (liga == null)
            {
                return HttpNotFound();
            }
            return View(liga);
        }

        // POST: Liga/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Status")] Liga liga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liga);
        }

        // GET: Liga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Liga liga = db.Ligas.Find(id);
            if (liga == null)
            {
                return HttpNotFound();
            }
            return View(liga);
        }

        // POST: Liga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Liga liga = db.Ligas.Find(id);
            db.Ligas.Remove(liga);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private bool ValidarStatusLiga(List<Time> times)
        {
            // A liga deve ter exatamente 20 times
            if (times.Count != 20)
                return false;

            foreach (var time in times)
            {
                if (time.Jogadores.Count < 30)
                    return false;

                if (time.ComissaoTecnica.Count < 5)
                    return false;

                var cargos = time.ComissaoTecnica.Select(c => c.Cargo).Distinct();
                if (cargos.Count() < 5)
                    return false;
            }

            return true;
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
