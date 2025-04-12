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
    public class EstatisticaPartidaController : Controller
    {
        private LigaTabajaraFutebol db = new LigaTabajaraFutebol();

        // GET: EstatisticaPartida
        public ActionResult Index()
        {
            var estatisticaspartida = db.EstatisticasPartida.Include(e => e.Jogador).Include(e => e.Partida);
            return View(estatisticaspartida.ToList());
        }

        // GET: EstatisticaPartida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstatisticaPartida estatisticaPartida = db.EstatisticasPartida.Find(id);
            if (estatisticaPartida == null)
            {
                return HttpNotFound();
            }
            return View(estatisticaPartida);
        }

        // GET: EstatisticaPartida/Create
        public ActionResult Create()
        {
            ViewBag.JogadorId = new SelectList(db.Jogadores, "Id", "Nome");
            ViewBag.PartidaId = new SelectList(db.Partidas, "Id", "Estadio");
            return View();
        }

        // POST: EstatisticaPartida/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PartidaId,JogadorId,TimeId,GolsMarcados,GolsSofridos,Asistencias,CartoesAmarelos,CartoesVermelhos")] EstatisticaPartida estatisticaPartida)
        {
            if (ModelState.IsValid)
            {
                db.EstatisticasPartida.Add(estatisticaPartida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JogadorId = new SelectList(db.Jogadores, "Id", "Nome", estatisticaPartida.JogadorId);
            ViewBag.PartidaId = new SelectList(db.Partidas, "Id", "Estadio", estatisticaPartida.PartidaId);
            return View(estatisticaPartida);
        }

        // GET: EstatisticaPartida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstatisticaPartida estatisticaPartida = db.EstatisticasPartida.Find(id);
            if (estatisticaPartida == null)
            {
                return HttpNotFound();
            }
            ViewBag.JogadorId = new SelectList(db.Jogadores, "Id", "Nome", estatisticaPartida.JogadorId);
            ViewBag.PartidaId = new SelectList(db.Partidas, "Id", "Estadio", estatisticaPartida.PartidaId);
            return View(estatisticaPartida);
        }

        // POST: EstatisticaPartida/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PartidaId,JogadorId,TimeId,GolsMarcados,GolsSofridos,Asistencias,CartoesAmarelos,CartoesVermelhos")] EstatisticaPartida estatisticaPartida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estatisticaPartida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JogadorId = new SelectList(db.Jogadores, "Id", "Nome", estatisticaPartida.JogadorId);
            ViewBag.PartidaId = new SelectList(db.Partidas, "Id", "Estadio", estatisticaPartida.PartidaId);
            return View(estatisticaPartida);
        }

        // GET: EstatisticaPartida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstatisticaPartida estatisticaPartida = db.EstatisticasPartida.Find(id);
            if (estatisticaPartida == null)
            {
                return HttpNotFound();
            }
            return View(estatisticaPartida);
        }

        // POST: EstatisticaPartida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstatisticaPartida estatisticaPartida = db.EstatisticasPartida.Find(id);
            db.EstatisticasPartida.Remove(estatisticaPartida);
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
