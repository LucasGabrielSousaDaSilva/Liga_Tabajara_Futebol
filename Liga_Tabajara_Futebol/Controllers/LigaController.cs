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

        public ActionResult Liga()
        {
            var times = GerarTimesFake();
            var partidasRodada = GerarPartidasFake(times);
            //var classificacao = CalcularClassificacao(times, partidasRodada);

            ViewBag.RodadaAtual = 4;

            var model = new LigaHomeViewModel
            {
                Times = times,
                Partidas = partidasRodada,
                //Classificacao = classificacao
            };

            return View(model);
        }

        private List<Time> GerarTimesFake()
        {
            var times = new List<Time>();
            for (int i = 1; i <= 20; i++)
            {
                var time = new Time
                {
                    Id = i,
                    Nome = "Time " + i,
                    Jogadores = new List<Jogador>(),
                    ComissaoTecnica = new List<ComissaoTecnica>()
                };
                for (int j = 1; j <= 30; j++)
                {
                    time.Jogadores.Add(new Jogador { Id = j, Nome = "Jogador " + j });
                }
                for (int k = 1; k <= 5; k++)
                {
                    time.ComissaoTecnica.Add(new ComissaoTecnica { Id = k});
                }
                times.Add(time);
            }
            return times;
        }

        private List<Partida> GerarPartidasFake(List<Time> times)
        {
            var partidas = new List<Partida>();
            for (int i = 0; i < times.Count; i++)
            {
                for (int j = i + 1; j < times.Count; j++)
                {
                    partidas.Add(new Partida
                    {
                        TimeCasaId = times[i],
                        TimeForaId = times[j],
                        Data = DateTime.Now.AddDays(i + j)
                    });
                }
            }
            return partidas;
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

        public ActionResult Home()
        {
            // MOCK: Simulando dados de jogos
            var jogosRodada = new List<JogoViewModel>
            {
                new JogoViewModel { TimeCasa = "Internacional", GolsCasa = 0, TimeFora = "Palmeiras", GolsFora = 1, Minuto = 72 },
                new JogoViewModel { TimeCasa = "Corinthians", GolsCasa = 0, TimeFora = "Fluminense", GolsFora = 1, Minuto = 74 },
                new JogoViewModel { TimeCasa = "Sport Recife", GolsCasa = 0, TimeFora = "Bragantino", GolsFora = 1, Finalizado = true },
                new JogoViewModel { TimeCasa = "EC Vitória", GolsCasa = 0, TimeFora = "Fortaleza", Horario = "21:30" },
                new JogoViewModel { TimeCasa = "Santos", GolsCasa = 0, TimeFora = "Atlético-MG", Horario = "21:30" },
                new JogoViewModel { TimeCasa = "Flamengo", GolsCasa = 0, TimeFora = "Juventude", Horario = "21:30" }
            };

            // MOCK: Classificação
            var classificacao = new List<ClassificacaoItem>
            {
                new ClassificacaoItem { NomeTime = "Internacional", Vitorias = 2, Empates = 1, Derrotas = 1, SaldoGols = 3, Pontos = 7 },
                new ClassificacaoItem { NomeTime = "Palmeiras", Vitorias = 3, Empates = 0, Derrotas = 1, SaldoGols = 5, Pontos = 9 },
                new ClassificacaoItem { NomeTime = "Corinthians", Vitorias = 1, Empates = 2, Derrotas = 1, SaldoGols = -1, Pontos = 5 },
                new ClassificacaoItem { NomeTime = "Fluminense", Vitorias = 2, Empates = 0, Derrotas = 2, SaldoGols = -2, Pontos = 6 }
            };

            var model = new LigaHomeViewModel
            {
                Rodada = 4,
                Jogos = jogosRodada,
                Classificacao = classificacao
            };

            return View(model);
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
