namespace LojaInformatica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegistroAcaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        acaoTomada = c.Int(nullable: false),
                        usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.usuario_Id)
                .Index(t => t.usuario_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Email = c.String(),
                        Senha = c.String(),
                        Hash = c.String(),
                        Salt = c.String(),
                        NivelAcesso = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Pessoa = c.Int(nullable: false),
                        Sexo = c.Int(nullable: false),
                        Endereco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Enderecoes", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
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
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        marcaProduto = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(),
                        Descricao = c.String(),
                        Quantidade = c.Int(nullable: false),
                        PrecoUnitario = c.Double(nullable: false),
                        PrecoTotal = c.Double(nullable: false),
                        Marca_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Marcas", t => t.Marca_ID)
                .Index(t => t.Marca_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "Marca_ID", "dbo.Marcas");
            DropForeignKey("dbo.Clientes", "Endereco_Id", "dbo.Enderecoes");
            DropForeignKey("dbo.RegistroAcaos", "usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.Produtoes", new[] { "Marca_ID" });
            DropIndex("dbo.Clientes", new[] { "Endereco_Id" });
            DropIndex("dbo.RegistroAcaos", new[] { "usuario_Id" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Marcas");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.RegistroAcaos");
        }
    }
}
