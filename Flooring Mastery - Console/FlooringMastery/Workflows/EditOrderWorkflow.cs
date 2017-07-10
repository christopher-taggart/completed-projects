using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Workflows
{
    public class EditOrderWorkflow : IWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            
            Console.Clear();
            string date = ConsoleIO.GetValidDate("Enter the date of the order you are trying to edit.");

            OrderListResponse response = manager.GetOrdersByDate(date);

            if (!response.Success)
            {
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to return to Main Menu.");
                Console.ReadKey();
            }

            Console.Clear();
            foreach (var order in response.Orders)
            {
                ConsoleIO.DisplayOrder(order, date);
            }

            int orderNumber = ConsoleIO.GetOrderNumber("Enter the order number of the order you want to edit:");

            
            OrderResponse oResponse = manager.GetOrderByOrderNumber(response.Orders, orderNumber);
            if (!oResponse.Success)
            {
                Console.WriteLine(oResponse.Message);
                Console.WriteLine("Press any key to try again.");
                Console.ReadKey();
                return;
            }

            Console.Clear();
            Console.WriteLine($"Enter customer name ({oResponse.Order.CustomerName}):");
            string name = Console.ReadLine();
            if(name == "")
            {
                name = oResponse.Order.CustomerName;
            }

            Console.WriteLine($"Enter what state you or your company is located ({oResponse.Order.State}):");
            string state = Console.ReadLine();
            if (state == "")
            {
                state = oResponse.Order.State;
            }

      
            Console.WriteLine($"Enter the product type you would like to use ({oResponse.Order.ProductType}):");
            string pType = Console.ReadLine();
            if (pType == "")
            {
                pType = oResponse.Order.ProductType;
            }
            
            Console.WriteLine($"Enter in the total area of your flooring project (minimum 100 Sq Ft) ({oResponse.Order.Area}):");
            string temp = Console.ReadLine();
            decimal area;
            if (temp == "")
            {
                area = oResponse.Order.Area;
            }
            else
            {
                area = decimal.Parse(temp);
            }
            OrderResponse r = manager.EditOrder(date, name, state, pType, area, orderNumber);

            if (!r.Success)
            {
                Console.WriteLine(r.Message);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                return;
            }

            ConsoleIO.DisplayOrder(r.Order, date);
            Console.WriteLine("Are you sure you want to make these changes? Y / N");
            string input = Console.ReadLine().ToUpper();
            if (input != "Y")
            {
                Console.WriteLine("Your changes have been cancelled!");
                Console.WriteLine("Press any key to return to Main Menu.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("The edits you made have been processed");
            Console.WriteLine("Press any key to return to Main Menu.");
            Console.ReadKey();
            manager.RemoveOrder(response.Orders, orderNumber, date);
            manager.SaveOrder(r.Order, date);
        }
    }
}
