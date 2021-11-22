using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ProductsClient.ProductsService;

namespace ProductsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press ENTER when the service has started");
            Console.ReadLine();
            ProductsServiceClient proxy = new ProductsServiceClient("BasicHttpBinding_IProductsService");

            Console.WriteLine("Test 1: List all products");
            List<ProductData> products = proxy.ListProducts().ToList();

            foreach (ProductData p in products)
            {
                Console.WriteLine("Name: {0}", p.NameProduto);
                Console.WriteLine("Numero: {0}", p.NumeroProduto);
                Console.WriteLine("Estoque: {0}", p.EstoqueProduto);
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Test 2: Display the details of a product");
            ProductData product = proxy.GetProduct("1000");
            if (product != null)
            {
                Console.WriteLine("Name: {0}", product.NameProduto);
                Console.WriteLine("Numero: {0}", product.NumeroProduto);
                Console.WriteLine("Estoque: {0}", product.EstoqueProduto);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No such product");
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Test 3: Display the stoque of a product");
            int estoque = proxy.CurrentStockProduto("1000");
            if (estoque != 0)
            {
                Console.WriteLine("Estoque: {0}", estoque);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("No such product");
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Test 4: Display the add of a stoque product");

            if (proxy.AddStockProduto("1000", 100))
            {
                estoque = proxy.CurrentStockProduto("1000");
                Console.WriteLine("Stock changed. Current stock: {0}", estoque);
            }
            else
            {
                Console.WriteLine("Stock update failed");
            }

            Console.WriteLine();
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
