using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liga_Tabajara_Futebol.Models
{

    public enum Resultado
    {
        Vitoria,
        Empate,
        Derrota
    }


    public class Partida
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public Time TimeCasaId { get; set; }
        public Time TimeForaId { get; set; }
        public int GolsTimeCasa { get; set; }
        public int GolsTimeFora { get; set; }
        public string Estadio { get; set; }
        public Resultado Resultado { get; set; }
        public int Rodada { get; set; }

        public ICollection<EstatisticaPartida> Estatisticas { get; set; }

        public Partida()
        {
            GolsTimeCasa = 0;
            GolsTimeFora = 0;
        }
    }
}