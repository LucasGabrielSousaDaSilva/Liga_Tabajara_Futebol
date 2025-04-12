namespace Liga_Tabajara_Futebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogadors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Nacionalidade = c.String(),
                        Posicao = c.Int(nullable: false),
                        NumCamisa = c.Int(nullable: false),
                        Altura = c.Int(nullable: false),
                        Peso = c.Int(nullable: false),
                        PePreferido = c.Int(nullable: false),
                        Time_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Times", t => t.Time_Id)
                .Index(t => t.Time_Id);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Status = c.String(),
                        CoresUniformes = c.Boolean(nullable: false),
                        DataFundacao = c.DateTime(nullable: false),
                        Cidade = c.String(),
                        Estado = c.String(),
                        Estagio = c.String(),
                        CapacidadeEstagio = c.Int(nullable: false),
                        Vitorias = c.Int(nullable: false),
                        Empates = c.Int(nullable: false),
                        Derrotas = c.Int(nullable: false),
                        GolsMarcados = c.Int(nullable: false),
                        GolsSofridos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogadors", "Time_Id", "dbo.Times");
            DropIndex("dbo.Jogadors", new[] { "Time_Id" });
            DropTable("dbo.Times");
            DropTable("dbo.Jogadors");
        }
    }
}
