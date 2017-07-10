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
    public class LookupOrderWorkflow : IWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            string date = ConsoleIO.GetValidDate("Enter the date of the order you are attempting to look up:");

            OrderListResponse response = manager.GetOrdersByDate(date);

            if (!response.Success)
            {
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to return to Main Menu.");
                Console.ReadKey();
                return;
            }

            foreach (var order in response.Orders)
            {
                ConsoleIO.DisplayOrder(order, date);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }
    }
}
