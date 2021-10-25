namespace GuaritaVisitantes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Visitante06 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VeiculoVisitante",
                c => new
                    {
                        VeiculoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Placa = c.String(nullable: false),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VeiculoId);
            
            AddColumn("dbo.EntradasSaidas", "VeiculoId", c => c.Int());
            CreateIndex("dbo.EntradasSaidas", "VeiculoId");
            AddForeignKey("dbo.EntradasSaidas", "VeiculoId", "dbo.VeiculoVisitante", "VeiculoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntradasSaidas", "VeiculoId", "dbo.VeiculoVisitante");
            DropIndex("dbo.EntradasSaidas", new[] { "VeiculoId" });
            DropColumn("dbo.EntradasSaidas", "VeiculoId");
            DropTable("dbo.VeiculoVisitante");
        }
    }
}
