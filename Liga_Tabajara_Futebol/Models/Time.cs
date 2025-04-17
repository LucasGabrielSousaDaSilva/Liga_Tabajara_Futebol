using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Liga_Tabajara_Futebol.Models
{

    public class Time
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public string CorUniformesPrimaria { get; set; }
        public string CorUniformesSecundaria { get; set; }
        public DateTime DataFundacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string EstadioTime { get; set; }
        public int CapacidadeEstagio { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsMarcados { get; set; }
        public int GolsSofridos { get; set; }

        public int LigaId { get; set; }
        public Liga Liga { get; set; }

        public ICollection<Jogador> Jogadores { get; set; }
        public ICollection<ComissaoTecnica> ComissaoTecnica { get; set; }

        public Time()
        {
            Vitorias = 0;
            Empates = 0;
            Derrotas = 0;
            GolsMarcados = 0;
            GolsSofridos = 0;
        }
    }

}