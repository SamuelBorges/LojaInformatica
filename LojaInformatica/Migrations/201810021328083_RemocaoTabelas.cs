namespace LojaInformatica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemocaoTabelas : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegistroAcaos", "usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.RegistroAcaos", new[] { "usuario_Id" });
            DropTable("dbo.RegistroAcaos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegistroAcaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        acaoTomada = c.Int(nullable: false),
                        usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.RegistroAcaos", "usuario_Id");
            AddForeignKey("dbo.RegistroAcaos", "usuario_Id", "dbo.Usuarios", "Id");
        }
    }
}
