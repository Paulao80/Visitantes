namespace GuaritaVisitantes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Visitante04 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaidasEntradas", "Data", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SaidasEntradas", "Data");
        }
    }
}
