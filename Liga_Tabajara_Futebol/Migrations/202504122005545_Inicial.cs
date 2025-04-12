namespace Liga_Tabajara_Futebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstatisticaPartida",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartidaId = c.Int(nullable: false),
                        JogadorId = c.Int(nullable: false),
                        TimeId = c.Int(nullable: false),
                        GolsMarcados = c.Int(nullable: false),
                        GolsSofridos = c.Int(nullable: false),
                        Asistencias = c.Int(nullable: false),
                        CartoesAmarelos = c.Int(nullable: false),
                        CartoesVermelhos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jogador", t => t.JogadorId, cascadeDelete: true)
                .ForeignKey("dbo.Partida", t => t.PartidaId, cascadeDelete: true)
                .Index(t => t.PartidaId)
                .Index(t => t.JogadorId);
            
            CreateTable(
                "dbo.Jogador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Nacionalidade = c.String(),
                        Posicao = c.Int(nullable: false),
                        NumCamisa = c.Int(nullable: false),
                        Altura = c.Single(nullable: false),
                        Peso = c.Single(nullable: false),
                        PePreferido = c.Int(nullable: false),
                        Time_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Time", t => t.Time_Id)
                .Index(t => t.Time_Id);
            
            CreateTable(
                "dbo.Time",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Status = c.Boolean(nullable: false),
                        CorUniformesPrimaria = c.String(),
                        CorUniformesSecundaria = c.String(),
                        DataFundacao = c.DateTime(nullable: false),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Estadio = c.String(),
                        CapacidadeEstagio = c.Int(nullable: false),
                        Vitorias = c.Int(nullable: false),
                        Empates = c.Int(nullable: false),
                        Derrotas = c.Int(nullable: false),
                        GolsMarcados = c.Int(nullable: false),
                        GolsSofridos = c.Int(nullable: false),
                        LigaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Liga", t => t.LigaId, cascadeDelete: true)
                .Index(t => t.LigaId);
            
            CreateTable(
                "dbo.ComissaoTecnica",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cargo = c.Int(nullable: false),
                        DataNascimento = c.DateTime(nullable: false),
                        Time_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Time", t => t.Time_Id)
                .Index(t => t.Time_Id);
            
            CreateTable(
                "dbo.Liga",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Partida",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        GolsTimeCasa = c.Int(nullable: false),
                        GolsTimeFora = c.Int(nullable: false),
                        Estadio = c.String(),
                        Resultado = c.Int(nullable: false),
                        Rodada = c.Int(nullable: false),
                        TimeCasaId_Id = c.Int(),
                        TimeForaId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Time", t => t.TimeCasaId_Id)
                .ForeignKey("dbo.Time", t => t.TimeForaId_Id)
                .Index(t => t.TimeCasaId_Id)
                .Index(t => t.TimeForaId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Partida", "timeForaId_Id", "dbo.Time");
            DropForeignKey("dbo.Partida", "timeCasaId_Id", "dbo.Time");
            DropForeignKey("dbo.EstatisticaPartida", "PartidaId", "dbo.Partida");
            DropForeignKey("dbo.Time", "LigaId", "dbo.Liga");
            DropForeignKey("dbo.Jogador", "Time_Id", "dbo.Time");
            DropForeignKey("dbo.ComissaoTecnica", "Time_Id", "dbo.Time");
            DropForeignKey("dbo.EstatisticaPartida", "JogadorId", "dbo.Jogador");
            DropIndex("dbo.Partida", new[] { "timeForaId_Id" });
            DropIndex("dbo.Partida", new[] { "timeCasaId_Id" });
            DropIndex("dbo.ComissaoTecnica", new[] { "Time_Id" });
            DropIndex("dbo.Time", new[] { "LigaId" });
            DropIndex("dbo.Jogador", new[] { "Time_Id" });
            DropIndex("dbo.EstatisticaPartida", new[] { "JogadorId" });
            DropIndex("dbo.EstatisticaPartida", new[] { "PartidaId" });
            DropTable("dbo.Partida");
            DropTable("dbo.Liga");
            DropTable("dbo.ComissaoTecnica");
            DropTable("dbo.Time");
            DropTable("dbo.Jogador");
            DropTable("dbo.EstatisticaPartida");
        }
    }
}
