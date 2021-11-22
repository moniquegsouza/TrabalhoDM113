using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Products
{
    [ServiceContract]
    public interface IProductsService
    {
        // Get all products
        [OperationContract]
        List<ProductData> ListProducts();
        // Get the details of a single product
        [OperationContract]
        ProductData GetProduct(string numeroProduto);
        // Get the current stock for a product
        [OperationContract]
        int CurrentStockProduto(string numeroproduct);
        // Add stock for a product
        [OperationContract]
        bool AddStockProduto(string numeroProduct, int quantity);
    }

    [DataContract]
    public class ProductData
    {
        [DataMember]
        public string NumeroProduto;
        [DataMember]
        public string NameProduto;
        [DataMember]
        public string DescricaoProduto;
        [DataMember]
        public int EstoqueProduto;
    }
}