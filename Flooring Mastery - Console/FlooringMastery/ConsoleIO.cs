using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery
{
    public class ConsoleIO
    {
        public static decimal GetDecimal()
        {
            decimal area;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter in the total area of your flooring project (minimum 100 Sq Ft):");
                if (!decimal.TryParse(Console.ReadLine(), out area))
                {
                   

                        Console.WriteLine("Your area entry is invalid.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                  
                }
                else return area;
            }

        }
        public static string GetValidCompanyName()
        {
            string s = null;
            
            while(s == null)
            {
                Console.Clear();
                Console.WriteLine("Enter your company's name:");
                 s = Console.ReadLine();
                if (s.Length < 1)
                {
                    Console.WriteLine("You cannot leave this field blank. Enter in a valid name.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                    s = null;
                }
            } 

            return s;
        }

        public static string GetValidDate(string prompt)
        {
            
            
            do
            {
                Console.Clear();
                DateTime d;
                Console.WriteLine(prompt);
                if (DateTime.TryParse(Console.ReadLine(), out d))
                {
                    string date = d.ToString("MM/dd/yyyy");
                    return date;
                }
                else
                {
                    Console.WriteLine("Your date is invalid. Enter a valid date.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }

            } while (true);
            
            
        }

        public static void DisplayOrder(Order order, string date)
        {
            Console.WriteLine("******************************");
            Console.WriteLine($"{order.OrderNumber}   |   {date}\n{order.CustomerName}\n{order.State}\nProduct: {order.ProductType}\nMaterials:\t{order.MaterialCost:C}\nLabor:\t\t{order.LaborCost:C}\nTax:\t\t{order.Tax:C}\n------------------------------\nTotal:\t\t{order.Total:C}");
            Console.WriteLine("******************************");

        }

      

        public static int GetOrderNumber(string prompt)
        {
            
            while (true)
            {
                
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }
                Console.WriteLine("Invalid number. Try Again.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
            
        }
        
    }
}
