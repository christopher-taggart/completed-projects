using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public class ConsoleInput
    {
        public static Coordinate ConvertToCord(string cord)
        {
            int x;
            int y;
            
            cord = cord.ToUpper();
            if (cord == "")
            {
                cord = "K1";

            }
            
                x = (char.Parse(cord.Substring(0, 1)) - 64);
            if (cord.Length > 1)
            {
                y = (int.Parse(cord.Substring(1)));
            }
            else
            {
                y = 11;
            }


            Coordinate xy = new Coordinate(x, y);
            return xy;
        }

        public static bool ValidateCord(Coordinate xy)
        {
            if (xy.XCoordinate < 0 || xy.XCoordinate > 10 || xy.YCoordinate < 0 || xy.YCoordinate > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
