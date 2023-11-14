using Battleship_bonus_project.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project.Ships
{
    internal class Battleship : Ship
    {
        public Battleship()
        {
            name = "Battleship";
            this.length = 4;
            ship = new Tile[length];
        }
    }
}
