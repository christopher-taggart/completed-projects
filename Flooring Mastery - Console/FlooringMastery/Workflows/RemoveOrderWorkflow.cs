using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Workflows
{
    public class RemoveOrderWorkflow : IWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            string date = ConsoleIO.GetValidDate("Enter the date of the order you want to remove:");

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
            int orderNumber = ConsoleIO.GetOrderNumber("Enter the order number of the order you want to remove:");

            Console.Clear();
            foreach (var order in response.Orders)
            {
                if (orderNumber == order.OrderNumber)
                {
                    ConsoleIO.DisplayOrder(order, date);
                    response.Success = true;
                    break;

                }
                else response.Success = false;
                response.Message = "No orders match the order number given.";
            }
            if (response.Success)
            {
                Console.WriteLine("Are you sure you want to delete this order? Y/N");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    
                    manager.RemoveOrder(response.Orders, orderNumber, date);
                    Console.WriteLine("Order successfully deleted.");
                    Console.WriteLine("Press any key to go back to Main Menu.");
                    Console.ReadKey();
                    
                }
                return;
            }

            Console.WriteLine("Order deletion cancelled.");
            Console.WriteLine("Press any key to go back to Main Menu.");
            Console.ReadKey();
        }
    }
}
