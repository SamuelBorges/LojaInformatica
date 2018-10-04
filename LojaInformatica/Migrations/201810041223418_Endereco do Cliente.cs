namespace LojaInformatica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnderecodoCliente : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientes", "Endereco_Id", "dbo.Enderecoes");
            DropIndex("dbo.Clientes", new[] { "Endereco_Id" });
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataDoPedido = c.DateTime(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        Observacao = c.String(),
                        Cliente_Id = c.Int(),
                        Produto_Id = c.Int(),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Cliente_Id)
                .ForeignKey("dbo.Produtoes", t => t.Produto_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Cliente_Id)
                .Index(t => t.Produto_Id)
                .Index(t => t.Usuario_Id);
            
            AddColumn("dbo.Clientes", "CEP", c => c.String());
            AddColumn("dbo.Clientes", "Cidade", c => c.String());
            AddColumn("dbo.Clientes", "Bairro", c => c.String());
            AddColumn("dbo.Clientes", "Rua", c => c.String());
            AddColumn("dbo.Clientes", "NumeroCasa", c => c.Int(nullable: false));
            AddColumn("dbo.Clientes", "Complemento", c => c.String());
            DropColumn("dbo.Clientes", "Endereco_Id");
            DropTable("dbo.Enderecoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CEP = c.String(),
                        Cidade = c.String(),
                        Bairro = c.String(),
                        Rua = c.String(),
                        NumeroCasa = c.String(),
                        Complemento = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clientes", "Endereco_Id", c => c.Int());
            DropForeignKey("dbo.Pedidoes", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Pedidoes", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Pedidoes", "Cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Pedidoes", new[] { "Usuario_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Produto_Id" });
            DropIndex("dbo.Pedidoes", new[] { "Cliente_Id" });
            DropColumn("dbo.Clientes", "Complemento");
            DropColumn("dbo.Clientes", "NumeroCasa");
            DropColumn("dbo.Clientes", "Rua");
            DropColumn("dbo.Clientes", "Bairro");
            DropColumn("dbo.Clientes", "Cidade");
            DropColumn("dbo.Clientes", "CEP");
            DropTable("dbo.Pedidoes");
            CreateIndex("dbo.Clientes", "Endereco_Id");
            AddForeignKey("dbo.Clientes", "Endereco_Id", "dbo.Enderecoes", "Id");
        }
    }
}
