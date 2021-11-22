namespace ProductsEntityModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criacao_Banco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroProduto = c.String(),
                        NameProduto = c.String(),
                        DescricaoProduto = c.String(),
                        EstoqueProduto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
