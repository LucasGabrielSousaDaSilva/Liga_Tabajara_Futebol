using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Liga_Tabajara_Futebol.Models
{
	public enum Posicao
    {
        Goleiro,
        Zagueiro,
        Lateral,
        MeioCampo,
        Atacante
    }

    public enum PePreferido
    {
        Direito,
        Esquerdo,
        Ambidestro
    }

    public class Jogador
	{
        public int Id { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public Posicao Posicao { get; set; }
        public int NumCamisa { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public PePreferido PePreferido { get; set; }
        public Time Time { get; set; }

        public ICollection<EstatisticaPartida> Estatisticas { get; set; }

    }
}