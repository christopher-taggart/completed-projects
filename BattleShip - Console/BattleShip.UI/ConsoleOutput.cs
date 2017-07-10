using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class ConsoleOutput
    {
       
        public static void DisplaySplash()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n                                                      Welcome\n                                                        TO\n                                                    BATTLESHIP");
            Console.ReadLine();
        }

        public static void DisplayNotEnoughSpace()
        {
            Console.WriteLine("Sorry, not enough space.");
            Console.ReadLine();
        }

        public static void DisplayOverlap()
        {
            Console.WriteLine("Sorry this ship overlaps with another. Try again.");
            Console.ReadLine();
        }

        public static void DisplayHit()
        {
            Console.Clear();
            Console.WriteLine("That's a hit!");
            Console.ReadLine();
        }

        public static void DisplayMiss()
        {
            Console.Clear();
            Console.WriteLine("Sorry, you missed.");
            Console.ReadLine();
        }

        public static void DisplayHitAndSunk()
        {
            Console.Clear();
            Console.WriteLine("That's a hit and sink!");
            Console.ReadLine();
        }

        public static void DisplayDuplicate()
        {
            Console.Clear();
            Console.WriteLine("You already tried that.");
            Console.ReadLine();
        }

        public static void DisplayInvalid()
        {
            Console.Clear();
            Console.WriteLine("That's an invalid coordinate.");
            Console.ReadLine();
        }

        public static void DisplayVictory()
        {
            Console.Clear();
            Console.WriteLine("That'll do it! You just won!!");
            Console.ReadLine();
        }
    }
}
