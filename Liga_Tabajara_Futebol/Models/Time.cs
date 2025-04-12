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
        public string Status { get; set; }
        public Boolean CoresUniformes { get; set; }
        public DateTime DataFundacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Estagio { get; set; }
        public int CapacidadeEstagio { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsMarcados { get; set; }
        public int GolsSofridos { get; set; }

        public Time()
        {
            Vitorias = 0;
            Empates = 0;
            Derrotas = 0;
            GolsMarcados = 0;
            GolsSofridos = 0;
        }
    }

    public class TimeDBContext : DbContext
    {
        public DbSet<Time> Times { get; set; }
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<ComissaoTecnica> ComissaoTecnica { get; set; }
    }
}