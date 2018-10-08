namespace LojaInformatica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pedidosupdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Clientes");
            DropForeignKey("dbo.Pedidoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Pedidoes", new[] { "Cliente_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Produto_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Usuario_Id" });
            AddColumn("dbo.Pedidoes", "Cliente", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "Produto", c => c.Int(nullable: false));
            AddColumn("dbo.Pedidoes", "Usuario", c => c.Int(nullable: false));
            DropColumn("dbo.Pedidoes", "Cliente_Id");
            DropColumn("dbo.Pedidoes", "Produto_Id");
            DropColumn("dbo.Pedidoes", "Usuario_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pedidoes", "Usuario_Id", c => c.Int());
            AddColumn("dbo.Pedidoes", "Produto_Id", c => c.Int());
            AddColumn("dbo.Pedidoes", "Cliente_Id", c => c.Int());
            DropColumn("dbo.Pedidoes", "Usuario");
            DropColumn("dbo.Pedidoes", "Produto");
            DropColumn("dbo.Pedidoes", "Cliente");
            CreateIndex("dbo.Pedidoes", "Usuario_Id");
            CreateIndex("dbo.Pedidoes", "Produto_Id");
            CreateIndex("dbo.Pedidoes", "Cliente_Id");
            AddForeignKey("dbo.Pedidoes", "Usuario_Id", "dbo.Usuarios", "Id");
            AddForeignKey("dbo.Pedidoes", "Produto_Id", "dbo.Produtoes", "Id");
            AddForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Clientes", "Id");
        }
    }
}
