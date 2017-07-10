using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    class SetupShips
    {
        public static void ShipSetup(Player p1, Player p2)
    {
        int x = 0;
        int y = 0;
        Coordinate xy = new Coordinate(x, y);
        ShipDirection direction = ShipDirection.Down;
        bool IsValid = true;
        string DirResponse = "";
        PlaceShipRequest psr = new PlaceShipRequest();
        ShipPlacement response;
        
            for (int k = 0; k < 2; k++)
            {
                if (k == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"{p1.Name}, you're all set up!");
                    Console.WriteLine($"\nNow let's have {p2.Name} set up his ships.");
                    Console.ReadLine();
                }
                foreach (ShipType stype in Enum.GetValues(typeof(ShipType)))
                {
                    do
                    {


                        do
                        {
                            if (k == 0)
                            {
                                Console.Clear();
                                VisualBoard.HitBoard(p1);
                                Console.WriteLine($"{p1.Name}, choose a coordinate for your {stype}:");
                            }
                            else
                            {
                                Console.Clear();
                                VisualBoard.HitBoard(p1);
                                Console.WriteLine($"{p2.Name}, choose a coordinate for your {stype}:");
                            }

                            string cord = Console.ReadLine();

                            xy = ConsoleInput.ConvertToCord(cord);

                            IsValid = ConsoleInput.ValidateCord(xy);
                            Console.Clear();

                          
                        } while (IsValid == false);

                        if (IsValid == true)
                        {
                            do
                            {
                                Console.WriteLine(
                                    $"Now choose a direction for your {stype}\n1 - Up, 2 - Down, 3 - Right, 4 - Left");
                                DirResponse = Console.ReadLine();
                                switch (DirResponse)
                                {
                                    case "1":
                                        direction = ShipDirection.Up;
                                        IsValid = true;
                                        break;
                                    case "2":
                                        direction = ShipDirection.Down;
                                        IsValid = true;
                                        break;
                                    case "3":
                                        direction = ShipDirection.Right;
                                        IsValid = true;
                                        break;
                                    case "4":
                                        direction = ShipDirection.Left;
                                        IsValid = true;
                                        break;
                                    default:
                                        Console.Clear();
                                        Console.WriteLine("That was not a valid direction response. Try Again");
                                        Console.ReadLine();
                                        Console.Clear();
                                        IsValid = false;
                                        break;
                                }

                            } while (IsValid == false);
                            Console.Clear();

                            psr.Coordinate = xy;
                            psr.Direction = direction;
                            psr.ShipType = stype;



                        }

                        if (k == 0)
                        {
                            response = p1.pBoard.PlaceShip(psr);
                        }
                        else
                        {
                            response = p2.pBoard.PlaceShip(psr);
                        }
                        if (response == ShipPlacement.NotEnoughSpace)
                        {
                            ConsoleOutput.DisplayNotEnoughSpace();
                        }
                        else if (response == ShipPlacement.Overlap)
                        {
                            ConsoleOutput.DisplayOverlap();
                        }
                        else
                        {
                            Console.WriteLine("Good Job");


                            Console.ReadLine();

                        }
                    } while (response != ShipPlacement.Ok);


                }
            }
        }
    }
}
