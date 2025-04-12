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
    public class TimeController : Controller
    {
        private LigaTabajaraFutebol db = new LigaTabajaraFutebol();

        // GET: Time
        public ActionResult Index()
        {
            var times = db.Times.Include(t => t.Liga);
            return View(times.ToList());
        }

        // GET: Time/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }

            return View(time);
        }

        // GET: Time/Create
        public ActionResult Create()
        {
            ViewBag.LigaId = new SelectList(db.Ligas, "Id", "Id");
            return View();
        }

        // POST: Time/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Status,CorUniformesPrimaria,CorUniformesSecundaria,DataFundacao,Cidade,Estado,Estagio,CapacidadeEstagio,Vitorias,Empates,Derrotas,GolsMarcados,GolsSofridos,LigaId")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Times.Add(time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LigaId = new SelectList(db.Ligas, "Id", "Id", time.LigaId);
            return View(time);
        }

        // GET: Time/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            ViewBag.LigaId = new SelectList(db.Ligas, "Id", "Id", time.LigaId);
            return View(time);
        }

        // POST: Time/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Status,CorUniformesPrimaria,CorUniformesSecundaria,DataFundacao,Cidade,Estado,Estagio,CapacidadeEstagio,Vitorias,Empates,Derrotas,GolsMarcados,GolsSofridos,LigaId")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LigaId = new SelectList(db.Ligas, "Id", "Id", time.LigaId);
            return View(time);
        }

        // GET: Time/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // POST: Time/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Time time = db.Times.Find(id);
            db.Times.Remove(time);
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
