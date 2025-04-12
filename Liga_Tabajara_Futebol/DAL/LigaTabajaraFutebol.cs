using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Liga_Tabajara_Futebol.DAL
{
    public class LigaTabajaraFutebol : DbContext
    {
        public LigaTabajaraFutebol() : base("LigaTabajaraFutebol")
        {
        }
        public DbSet<Models.Liga> Ligas { get; set; }
        public DbSet<Models.ComissaoTecnica> ComissaoTecnica { get; set; }
        public DbSet<Models.Time> Times { get; set; }
        public DbSet<Models.Jogador> Jogadores { get; set; }
        public DbSet<Models.Partida> Partidas { get; set; }
        public DbSet<Models.EstatisticaPartida> Ator { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}