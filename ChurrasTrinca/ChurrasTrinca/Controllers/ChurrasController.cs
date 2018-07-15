using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChurrasTrinca.Models;
using ChurrasTrinca.DAL;
using System.Data.Entity;

namespace ChurrasTrinca.Controllers
{
    public class ChurrasController : Controller
    {
        private ChurrasModelContext db = new ChurrasModelContext();

        public ActionResult Churras()
        {
            return View(db.Churras.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Participantes(int id = 0)
        {
            Churras churras = db.Churras.Find(id);
            if (churras == null)
            {
                return HttpNotFound();
            }
            return View(churras);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Churras churras)
        {
            if (ModelState.IsValid)
            {
                db.Churras.Add(churras);
                db.SaveChanges();
                return RedirectToAction("Churras");
            }

            return View(churras);
        }

        public ActionResult Details(int id = 0)
        {
            Churras churras = db.Churras.Find(id);
            if (churras == null)
            {
                return HttpNotFound();
            }
            return View(churras);
        }

        public ActionResult Edit(int id = 0)
        {
            Churras churras = db.Churras.Find(id);
            if (churras == null)
            {
                return HttpNotFound();
            }
            return View(churras);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Churras churras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(churras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Churras");
            }
            return View(churras);
        }


        public string AddNovoParticipanteChurras(int idChurras, String txtNome, decimal txtContribuicao,bool ckcPago,
            String txtObs, bool rdComBebida, bool rdSemBebida)
        {
            Participante participante = new Participante();
            participante.Nome = txtNome;
            participante.contribuicao = txtContribuicao;
            participante.Observacao = txtObs;
            participante.Pago = ckcPago;
            participante.Bebida = rdComBebida;

            db.Churras.Find(idChurras).Participantes.Add(participante);
            db.SaveChanges();

            return "OK";
        }

        public ActionResult DeletaChurras(int id = 0)
        {
            Churras churras = db.Churras.Find(id);

            foreach(var item in churras.Participantes.ToList())
            {
                db.Participantes.Remove(item);
            }

            db.Churras.Remove(churras);
            db.SaveChanges();

            return RedirectToAction("Churras", "Churras");
        }

        public ActionResult DeletaParticipante(int idParticipante = 0, int idChurras = 0)
        {
            Participante participante = db.Participantes.Find(idParticipante);
            db.Participantes.Remove(participante);
            db.SaveChanges();

            return RedirectToAction("Details","Churras", new { id = idChurras});
        }

        public ActionResult wcfPage()
        {
            return View();
        }







    }
}
