using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class GameFlow
    {
        Player p1 = new Player();
        Player p2 = new Player();

        
        public void Play()
        {
            bool PlayAgain = true;
            do
            {


                Console.Clear();
                ConsoleOutput.DisplaySplash();
                Console.Clear();

                
                Console.WriteLine("Player 1, enter your name: ");
                p1.Name = Console.ReadLine();
                Console.Clear();


                Console.WriteLine("Player 2, enter your name: ");
                p2.Name = Console.ReadLine();
                Console.Clear();

                
                SetupShips.ShipSetup(p1, p2);
               
                
                ActualGame.StartGame(p1, p2);

                Console.WriteLine("Do you want to play again?\nType Y - yes or N - no");
                string yes = Console.ReadLine();
                if (yes == "Y" || yes == "y")
                {
                    PlayAgain = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Thanks for playing!");
                    Console.ReadLine();
                    PlayAgain = false;
                }


            } while(PlayAgain == false);
        }
    }
}
