using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
    class Player
    {
        public string Name { get; set; }
        public Board pBoard { get; private set; }

        public Player()
        {
            Name = "name";
            pBoard = new Board();
        }

       
    }
}
