using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public class ProductRepository : IProductRepository
    {
        private string _pFileName;
        public ProductRepository(string pFileName)
        {
            _pFileName = pFileName;
        }
        public List<Product> GetAllProductInfo()
        {
            List<Product>products = new List<Product>();
            using (StreamReader sr = new StreamReader(_pFileName))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Product p = new Product();
                    string[] fields = line.Split(',');
                    p.ProductType = fields[0];
                    p.CostPerSquareFoot = decimal.Parse(fields[1]);
                    p.LaborCostPerSquareFoot = decimal.Parse(fields[2]);
                    products.Add(p);
                }
                return products;
            }
        }

        public Product GetProductByType(string type)
        {
            Product p = null;
            List<Product> products = GetAllProductInfo();
            foreach (var product in products)
            {
                if (type.ToUpper() == product.ProductType.ToUpper())
                {
                    p = product;
                }
            }
            return p;
        }
    }
}
