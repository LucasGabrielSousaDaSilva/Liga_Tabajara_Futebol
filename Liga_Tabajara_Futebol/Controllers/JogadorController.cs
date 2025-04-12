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
    public class JogadorController : Controller
    {
        private LigaTabajaraFutebol db = new LigaTabajaraFutebol();

        // GET: Jogador
        public ActionResult Index(string nome, Posicao? posicao, PePreferido? pe)
        {
            var query = db.Jogadores.AsQueryable();
            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(j => j.Nome.Contains(nome));
            }
            if (posicao.HasValue)
            {
                query = query.Where(j => j.Posicao == posicao.Value);
            }
            if (pe.HasValue)
            {
                query = query.Where(j => j.PePreferido == pe.Value);
            }
            // Adicione outros filtros conforme necessário
            return View(query.ToList());
        }

        // GET: Jogador/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = db.Jogadores.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        // GET: Jogador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jogador/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataNascimento,Nacionalidade,Posicao,NumCamisa,Altura,Peso,PePreferido")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.Jogadores.Add(jogador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jogador);
        }

        // GET: Jogador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = db.Jogadores.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        // POST: Jogador/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataNascimento,Nacionalidade,Posicao,NumCamisa,Altura,Peso,PePreferido")] Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jogador);
        }

        // GET: Jogador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = db.Jogadores.Find(id);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        // POST: Jogador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogador jogador = db.Jogadores.Find(id);
            db.Jogadores.Remove(jogador);
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
