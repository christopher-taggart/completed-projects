using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringMastery.Data;

namespace FlooringMastery.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {

            string mode = ConfigurationManager.AppSettings["Mode"];
            OrderManager manager;

            switch (mode)
            {
              
                case "FilePath":
                    string filename = ConfigurationManager.AppSettings["FilePath"];
                    string tFileName = ConfigurationManager.AppSettings["tFilePath"];
                    string pFileName = ConfigurationManager.AppSettings["pFilePath"];
                    return new OrderManager(new OrderRepository(filename), new TaxRepository(tFileName), new ProductRepository(pFileName));
                case "Test":
                    string testFilename = ConfigurationManager.AppSettings["Test"];
                    tFileName = ConfigurationManager.AppSettings["tFilePath"];
                    pFileName = ConfigurationManager.AppSettings["pFilePath"];
                    return new OrderManager(new OrderTestRepository(testFilename), new TaxRepository(tFileName), new ProductRepository(pFileName));
                default:
                    throw new Exception("No repository found");
            }
        }
    }
}
