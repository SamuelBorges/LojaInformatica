namespace LojaInformatica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camposproduto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Produtoes", "Nome", c => c.String());
            DropColumn("dbo.Produtoes", "PrecoTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produtoes", "PrecoTotal", c => c.Double(nullable: false));
            DropColumn("dbo.Produtoes", "Nome");
        }
    }
}
