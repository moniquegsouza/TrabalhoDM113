using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using ProductsEntityModel;

namespace Products
{
    // WCF service that implements the service contract
    [AspNetCompatibilityRequirements(
    RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProductsService : IProductsService
    {
        public List<ProductData> ListProducts()
        {
            List<ProductData> productsList = new List<ProductData>();
            try
            {
                using (ProductsModel database = new ProductsModel())
                {
                    List<Product> products = (from product in database.Products
                                              select product).ToList();
                    foreach (Product product in products)
                    {
                        ProductData productData = new ProductData()
                        {
                            NumeroProduto = product.NumeroProduto,
                            NameProduto = product.NameProduto,
                            DescricaoProduto = product.NameProduto,
                            EstoqueProduto = product.EstoqueProduto
                        };
                        productsList.Add(productData);
                    }
                }
            }
            catch
            {
            }
            return productsList;
        }
        public ProductData GetProduct(string numeroProduto)
        {
            ProductData productData = null;
            try
            {
                using (ProductsModel database = new ProductsModel())
                {
                    Product matchingProduct = database.Products.First(
                    p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    productData = new ProductData()
                    {
                        NumeroProduto = matchingProduct.NumeroProduto,
                        NameProduto = matchingProduct.NameProduto,
                        DescricaoProduto = matchingProduct.NameProduto,
                        EstoqueProduto = matchingProduct.EstoqueProduto
                    };
                }
            }
            catch
            {
            }
            return productData;
        }
        public int CurrentStockProduto(string numeroProduto)
        {
            int quantityTotal = 0;
            try
            {
                using (ProductsModel database = new ProductsModel())
                {
                    quantityTotal = (from p in database.Products
                                     where String.Compare(p.NumeroProduto, numeroProduto) == 0
                                     select (int)p.EstoqueProduto).Sum();
                }
            }
            catch
            {
            }
            return quantityTotal;
        }
        public bool AddStockProduto(string numeroProduto, int quantity)
        {
            ProductData productData = null;

            try
            {
                using (ProductsModel database = new ProductsModel())
                {
                    Product matchingProduct = database.Products.First(
                    p => String.Compare(p.NumeroProduto, numeroProduto) == 0);
                    productData = new ProductData()
                    {
                        NumeroProduto = matchingProduct.NumeroProduto,
                        NameProduto = matchingProduct.NameProduto,
                        DescricaoProduto = matchingProduct.NameProduto,
                        EstoqueProduto = matchingProduct.EstoqueProduto
                    };
                    productData.EstoqueProduto = quantity;
                    database.Products.Add(matchingProduct);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}