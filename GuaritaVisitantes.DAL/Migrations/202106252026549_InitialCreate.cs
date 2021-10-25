namespace GuaritaVisitantes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntradasSaidas",
                c => new
                    {
                        EntradasSaidasId = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Observacoes = c.String(),
                        VisitanteId = c.Int(nullable: false),
                        IdUser = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EntradasSaidasId)
                .ForeignKey("dbo.Visitante", t => t.VisitanteId)
                .Index(t => t.VisitanteId);
            
            CreateTable(
                "dbo.Visitante",
                c => new
                    {
                        VisitanteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Telefone = c.String(nullable: false),
                        CnhRg = c.String(nullable: false),
                        CnhRgPath = c.String(),
                        FotoPath = c.String(),
                        IdUser = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VisitanteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EntradasSaidas", "VisitanteId", "dbo.Visitante");
            DropIndex("dbo.EntradasSaidas", new[] { "VisitanteId" });
            DropTable("dbo.Visitante");
            DropTable("dbo.EntradasSaidas");
        }
    }
}
