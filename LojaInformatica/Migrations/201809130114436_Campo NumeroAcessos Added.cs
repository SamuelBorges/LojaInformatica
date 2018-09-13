namespace LojaInformatica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampoNumeroAcessosAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuarios", "NumeroAcessos", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Usuarios", "NumeroAcessos");
        }
    }
}
