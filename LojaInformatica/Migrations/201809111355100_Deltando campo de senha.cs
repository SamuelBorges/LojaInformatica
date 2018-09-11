namespace LojaInformatica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Deltandocampodesenha : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Usuarios", "Senha");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuarios", "Senha", c => c.String());
        }
    }
}
