namespace GuaritaVisitantes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Visitante02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        NotificationId = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        Read = c.Boolean(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Notification");
        }
    }
}
