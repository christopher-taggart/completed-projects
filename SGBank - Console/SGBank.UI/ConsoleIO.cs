using SGBank.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class ConsoleIO
    {
        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Balance: {account.Balance:c}");
        }

        public static decimal ConvertToDecimal()
        {
            decimal output;
            while (true)
            {
                Console.Write("Enter a deposit amount: ");
                string userInput = Console.ReadLine();
                if (!decimal.TryParse(userInput, out output))
                {
                    
                    Console.WriteLine($"{userInput} is not a valid amount");
                    Console.WriteLine("Press any key to enter a different amount.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    return output;
                }
            }
        }
    }
}
