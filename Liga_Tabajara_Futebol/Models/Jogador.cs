using System;
using System.Collections.Generic;
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
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public Posicao Posicao { get; set; }
        public int NumCamisa { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public PePreferido PePreferido { get; set; }
        public Time Time { get; set; }

    }
}