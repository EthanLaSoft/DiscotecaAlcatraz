namespace DiscotecaAlcatraz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrearTablasIniciales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        Genero = c.String(nullable: false, maxLength: 50),
                        Fecha = c.DateTime(nullable: false),
                        Aforo = c.Int(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false, maxLength: 100),
                        TipoPlan = c.String(nullable: false, maxLength: 50),
                        NumeroPersonas = c.Int(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 10, scale: 2),
                        EventoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eventoes", t => t.EventoId)
                .Index(t => t.EventoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservas", "EventoId", "dbo.Eventoes");
            DropIndex("dbo.Reservas", new[] { "EventoId" });
            DropTable("dbo.Reservas");
            DropTable("dbo.Eventoes");
        }
    }
}
