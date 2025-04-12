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
        public DbSet<Models.Liga> Ligas { get; set; }
        public DbSet<Models.ComissaoTecnica> ComissaoTecnica { get; set; }
        public DbSet<Models.Time> Times { get; set; }
        public DbSet<Models.Jogador> Jogadores { get; set; }
        public DbSet<Models.Partida> Partidas { get; set; }
        public DbSet<Models.EstatisticaPartida> EstatisticasPartida { get; set; }

        public LigaTabajaraFutebol() : base("Liga")
        {
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}