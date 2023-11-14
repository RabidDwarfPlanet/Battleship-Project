using Battleship_bonus_project.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project.Ships
{
    internal class Aircraft : Ship
    {
        public Aircraft()
        {
            name = "Aircraft Carrier";
            this.length = 5;
            ship = new Tile[length];
        }
    }
}
