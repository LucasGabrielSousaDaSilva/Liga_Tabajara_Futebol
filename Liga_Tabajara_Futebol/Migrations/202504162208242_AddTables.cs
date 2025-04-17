namespace Liga_Tabajara_Futebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Partida", new[] { "timeCasaId_Id" });
            DropIndex("dbo.Partida", new[] { "timeForaId_Id" });
            CreateIndex("dbo.Partida", "TimeCasaId_Id");
            CreateIndex("dbo.Partida", "TimeForaId_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Partida", new[] { "TimeForaId_Id" });
            DropIndex("dbo.Partida", new[] { "TimeCasaId_Id" });
            CreateIndex("dbo.Partida", "timeForaId_Id");
            CreateIndex("dbo.Partida", "timeCasaId_Id");
        }
    }
}
