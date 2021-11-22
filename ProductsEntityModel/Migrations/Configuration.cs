namespace ProductsEntityModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductsEntityModel.ProductsModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductsEntityModel.ProductsModel context)
        {
            context.Products.AddOrUpdate(p => p.Id,
            new Product { NumeroProduto = "1000", NameProduto = "Produto 1", DescricaoProduto = "Este é o produto 1", EstoqueProduto = 100 },
            new Product { NumeroProduto = "2000", NameProduto = "Produto 2", DescricaoProduto = "Este é o produto 2", EstoqueProduto = 10 },
            new Product { NumeroProduto = "3000", NameProduto = "Produto 3", DescricaoProduto = "Este é o produto 3", EstoqueProduto = 200 },
            new Product { NumeroProduto = "4000", NameProduto = "Produto 4", DescricaoProduto = "Este é o produto 4", EstoqueProduto = 300 },
            new Product { NumeroProduto = "5000", NameProduto = "Produto 5", DescricaoProduto = "Este é o produto 5", EstoqueProduto = 400 },
            new Product { NumeroProduto = "6000", NameProduto = "Produto 6", DescricaoProduto = "Este é o produto 6", EstoqueProduto = 500 },
            new Product { NumeroProduto = "7000", NameProduto = "Produto 7", DescricaoProduto = "Este é o produto 7", EstoqueProduto = 30 },
            new Product { NumeroProduto = "7000", NameProduto = "Produto 8", DescricaoProduto = "Este é o produto 8", EstoqueProduto = 30 },
            new Product { NumeroProduto = "7000", NameProduto = "Produto 9", DescricaoProduto = "Este é o produto 9", EstoqueProduto = 400 },
            new Product { NumeroProduto = "7000", NameProduto = "Produto 10", DescricaoProduto = "Este é o produto 10", EstoqueProduto = 2 }
            ); context.SaveChanges();
        }
    }
}
