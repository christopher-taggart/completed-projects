using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Workflows;

namespace FlooringMastery
{
    public class Menu
    {
        public static void Start()
        {
          while (true)
            {
                Console.Clear();
                Console.WriteLine("Flooring Program");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Lookup an order");
                Console.WriteLine("2. Add an order");
                Console.WriteLine("3. Edit an order");
                Console.WriteLine("4. Remove an order");

                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter selection: ");

                string userinput = Console.ReadLine();

                switch (userinput)
                {
                    case "1":
                        LookupOrderWorkflow lookupWorkflow = new LookupOrderWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        AddOrderWorkflow addOrderWorkflow = new AddOrderWorkflow();
                        addOrderWorkflow.Execute();
                        break;
                    case "3":
                        EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
                        editOrderWorkflow.Execute();
                        break;
                    case "4":
                        RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();
                        removeOrderWorkflow.Execute();
                        break;
                    case "Q":
                        return;
                }

            }
        }
    }
}
