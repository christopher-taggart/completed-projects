using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Workflows
{
    public class AddOrderWorkflow : IWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            string date = ConsoleIO.GetValidDate("Enter the date you would like your order to be placed:");

            Console.Clear();
            string name = ConsoleIO.GetValidCompanyName();

            Console.Clear();
            Console.WriteLine("Enter what state you or your company is located:");
            string state = Console.ReadLine();

            Console.Clear();
            manager.DisplayProductInfo();
            Console.WriteLine("Enter the product type you would like to use:");
            string pType = Console.ReadLine();

            Console.Clear();

            decimal area = ConsoleIO.GetDecimal();

            OrderResponse response = manager.AddOrder(date, name, state, pType, area);

            Console.Clear();
            if (!response.Success)
            {
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
                
            }
            
            ConsoleIO.DisplayOrder(response.Order, date);
            Console.WriteLine("Do you want to place this order? Y / N");
            string input = Console.ReadLine().ToUpper();

            if (input != "Y")
            {
                Console.WriteLine("Your order has been cancelled!");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Order Placed!");
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadLine();
            manager.SaveOrder(response.Order, date);
        }
    }
}
