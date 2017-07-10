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
    class VisualBoard
    {
        public static void HitBoard(Player player)
        {
            int i;
            int j;

            Console.WriteLine("    A  B  C  D  E  F  G  H  I  J");

            
            for (j = 1; j < 11; j++)
            {

                Console.Write("\n");
                Console.Write($"{j}  ");


                for (i = 1; i < 11; i++)
                {
                    ShotHistory checkCoordinate = player.pBoard.CheckCoordinate(new Coordinate(i, j));
                    if (checkCoordinate == ShotHistory.Hit)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" H ");
                        Console.ResetColor();
                    }
                    else if (checkCoordinate == ShotHistory.Miss)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" M ");
                        Console.ResetColor();
                    }
                    else if (checkCoordinate == ShotHistory.Unknown)
                    {
                        Console.Write(" - ");
                    }
                    else
                    {
                        Console.Write(" - ");
                    }
                }


            }
            Console.WriteLine("\n\n");
        }
 
    }
}
