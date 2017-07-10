using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    class ActualGame
    {
        public static void StartGame(Player p1, Player p2)
        {Random rng = new Random();
          
            int whoseTurn = rng.Next(1, 3);
            bool isValid = true;
            Coordinate xy;
            bool Victory = false;
            FireShotResponse response = new FireShotResponse();
           
                if (whoseTurn == 1)
                {Console.WriteLine("Ok, let's get started!");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"{p1.Name}, you have been randomly chosen to go first.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {Console.Clear();
                    Console.WriteLine("Ok, let's get started!");
                    Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine($"{p2.Name}, you have been randomly chose to go first.");
                }
                while (Victory == false)
                {
                    if (whoseTurn == 1)
                    {
                        VisualBoard.HitBoard(p2);
                        //Getting cords to fire
                        Console.WriteLine($"{p1.Name} enter a coordinate to fire at");

                        string cord = Console.ReadLine();

                        xy = ConsoleInput.ConvertToCord(cord);
                        //setting fireshot response
                        response = p2.pBoard.FireShot(xy);
                        if (response.ShotStatus == ShotStatus.Duplicate)
                        {
                            ConsoleOutput.DisplayDuplicate();
                        }
                        else if (response.ShotStatus == ShotStatus.Hit)
                        {
                            ConsoleOutput.DisplayHit();
                        }
                        else if (response.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            ConsoleOutput.DisplayHitAndSunk();
                        }
                        else if (response.ShotStatus == ShotStatus.Invalid)
                        {
                            ConsoleOutput.DisplayInvalid();
                        }
                        else if (response.ShotStatus == ShotStatus.Miss)
                        {
                            ConsoleOutput.DisplayMiss();
                        }
                        else
                        {

                            ConsoleOutput.DisplayVictory();
                            Victory = true;

                        }
                        if (response.ShotStatus == ShotStatus.Duplicate)
                        {
                            whoseTurn = 1;
                        }
                        else if (response.ShotStatus == ShotStatus.Invalid)
                        {
                            whoseTurn = 1;
                        }
                        else
                        {
                            whoseTurn = 2;
                        }
                    }
                    else
                    {
                        VisualBoard.HitBoard(p1);
                        Console.WriteLine($"{p2.Name} enter a coordinate to fire at");

                        string cord = Console.ReadLine();

                        xy = ConsoleInput.ConvertToCord(cord);

                        response = p1.pBoard.FireShot(xy);
                        if (response.ShotStatus == ShotStatus.Duplicate)
                        {
                            ConsoleOutput.DisplayDuplicate();
                        }
                        else if (response.ShotStatus == ShotStatus.Hit)
                        {
                            ConsoleOutput.DisplayHit();
                        }
                        else if (response.ShotStatus == ShotStatus.HitAndSunk)
                        {
                            ConsoleOutput.DisplayHitAndSunk();
                        }
                        else if (response.ShotStatus == ShotStatus.Invalid)
                        {
                            ConsoleOutput.DisplayInvalid();
                        }
                        else if (response.ShotStatus == ShotStatus.Miss)
                        {
                            ConsoleOutput.DisplayMiss();
                        }
                        else
                        {

                            ConsoleOutput.DisplayVictory();
                            Victory = true;

                        }
                        if (response.ShotStatus == ShotStatus.Duplicate)
                        {
                            whoseTurn = 2;
                        }
                        else if (response.ShotStatus == ShotStatus.Invalid)
                        {
                            whoseTurn = 2;
                        }
                        else
                        {
                            whoseTurn = 1;
                        }
                    }
                }
            

        }
    }
}
