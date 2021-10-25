namespace GuaritaVisitantes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Visitante05 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Motorista", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Motorista", "Nome", c => c.Int(nullable: false));
        }
    }
}
