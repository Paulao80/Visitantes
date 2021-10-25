namespace GuaritaVisitantes.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Visitante03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Motorista",
                c => new
                    {
                        MotoristaId = c.Int(nullable: false, identity: true),
                        Nome = c.Int(nullable: false),
                        CnhRg = c.String(),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MotoristaId);
            
            CreateTable(
                "dbo.SaidasEntradas",
                c => new
                    {
                        SaidaEntradaId = c.Int(nullable: false, identity: true),
                        Tipo = c.Int(nullable: false),
                        KM = c.Double(),
                        Observacoes = c.String(),
                        VeiculoId = c.Int(nullable: false),
                        MotoristaId = c.Int(nullable: false),
                        SaidaId = c.Int(),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SaidaEntradaId)
                .ForeignKey("dbo.Motorista", t => t.MotoristaId)
                .ForeignKey("dbo.Veiculo", t => t.VeiculoId)
                .Index(t => t.VeiculoId)
                .Index(t => t.MotoristaId);
            
            CreateTable(
                "dbo.Veiculo",
                c => new
                    {
                        VeiculoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false),
                        Placa = c.String(nullable: false),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.VeiculoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SaidasEntradas", "VeiculoId", "dbo.Veiculo");
            DropForeignKey("dbo.SaidasEntradas", "MotoristaId", "dbo.Motorista");
            DropIndex("dbo.SaidasEntradas", new[] { "MotoristaId" });
            DropIndex("dbo.SaidasEntradas", new[] { "VeiculoId" });
            DropTable("dbo.Veiculo");
            DropTable("dbo.SaidasEntradas");
            DropTable("dbo.Motorista");
        }
    }
}
