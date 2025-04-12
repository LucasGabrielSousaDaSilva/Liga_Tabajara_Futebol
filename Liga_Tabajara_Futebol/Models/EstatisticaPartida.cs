using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liga_Tabajara_Futebol.Models
{
    public class EstatisticaPartida
    {

        public int Id { get; set; }
        public int PartidaId { get; set; }
        public Partida Partida { get; set; }
        public int JogadorId { get; set; }
        public Jogador Jogador { get; set; }
        public int TimeId { get; set; }
        public int GolsMarcados { get; set; }
        public int GolsSofridos { get; set; }
       // public int PosseDeBola { get; set; }
       // public int ChutesNoGol { get; set; }
       // public int ChutesForaDoGol { get; set; }
       // public int Escanteios { get; set; }
       // public int FaltasCometidas { get; set; }
       // public int FaltasSofridas { get; set; }
        public int Asistencias { get; set; }
        public int CartoesAmarelos { get; set; }
        public int CartoesVermelhos { get; set; }
        public EstatisticaPartida()
        {
            GolsMarcados = 0;
            GolsSofridos = 0;
            /* PosseDeBola = 0;
            ChutesNoGol = 0;
            ChutesForaDoGol = 0;
            Escanteios = 0;
            FaltasCometidas = 0;
            FaltasSofridas = 0; */
            Asistencias = 0;
            CartoesAmarelos = 0;
            CartoesVermelhos = 0;
        }
    }
}