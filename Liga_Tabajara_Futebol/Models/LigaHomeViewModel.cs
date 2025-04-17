using Liga_Tabajara_Futebol.Controllers;
using System.Collections.Generic;

namespace Liga_Tabajara_Futebol.Models
{
    public class LigaHomeViewModel
    {
        public List<Time> Times { get; set; }
        public List<Partida> Partidas { get; set; }
        public List<ClassificacaoItem> Classificacao { get; set; }
        public int Rodada { get; set; }
        public List<JogoViewModel> Jogos { get; set; }
    }

    public class ClassificacaoItem
    {
        public string NomeTime { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int SaldoGols { get; set; }
        public int Pontos { get; set; }
    }

    public class JogoViewModel
    {
        public string TimeCasa { get; set; }
        public int GolsCasa { get; set; }
        public string TimeFora { get; set; }
        public int GolsFora { get; set; }
        public bool Finalizado { get; set; }
        public string Horario { get; set; }
        public int? Minuto { get; set; }
    }

}
