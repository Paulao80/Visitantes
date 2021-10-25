namespace GuaritaVisitantes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Visitantes01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntradasSaidas", "EntradaId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EntradasSaidas", "EntradaId");
        }
    }
}
