using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public class OrderRepository : IOrderRepository
    {
        private string _filename;

        public OrderRepository(string filename)
        {
            _filename = filename;
        }

        public List<Order> LoadOrders(string date)
        {
            List<Order>Orders = new List<Order>();

            if (!File.Exists($@"{_filename}\Orders_{date}.txt"))
            {
                Orders = null;
                return Orders;
            }
            
                using (StreamReader sr = new StreamReader($@"{_filename}\Orders_{date}.txt"))
                {
                    sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Order o = new Order();
                        string[] fields = line.Split('|');
                        o.OrderNumber = int.Parse(fields[0]);
                        o.CustomerName = fields[1];
                        o.State = fields[2];
                        o.TaxRate = decimal.Parse(fields[3]);
                        o.ProductType = fields[4];
                        o.Area = decimal.Parse(fields[5]);
                        o.CostPerSquareFoot = decimal.Parse(fields[6]);
                        o.LaborCostPerSqareFoot = decimal.Parse(fields[7]);
                        o.MaterialCost = decimal.Parse(fields[8]);
                        o.LaborCost = decimal.Parse(fields[9]);
                        o.Tax = decimal.Parse(fields[10]);
                        o.Total = decimal.Parse(fields[11]);

                        Orders.Add(o);
                        

                    }
                
            }
            return Orders;


        }

        public void SaveOrder(List<Order> orders, string date)
        {
            if (orders.Count == 0)
            {
                File.Delete($@"{_filename}\Orders_{date}.txt");
                return;
            }

            using (StreamWriter sw = new StreamWriter($@"{_filename}\Orders_{date}.txt", false))
                {
                    sw.WriteLine(
                        "OrderNumber, CustomerName, State, TaxRate, ProductType, Area, CostPerSquareFoot, LaborCostPerSquareFoot, MaterialCost, LaborCost, Tax, Total");
                    foreach (var order in orders)
                    {
                        sw.WriteLine(
                        $"{order.OrderNumber}|{order.CustomerName}|{order.State}|{order.TaxRate}|{order.ProductType}|{order.Area}|{order.CostPerSquareFoot}|{order.LaborCostPerSqareFoot}|{order.MaterialCost}|{order.LaborCost}|{order.Tax}|{order.Total}");
                    }
                    
                }

            
            
        }
        
    }
}
