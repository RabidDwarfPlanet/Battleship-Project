using Battleship_bonus_project.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project.Ships
{
    internal class Submarine : Ship
    {
        public Submarine()
        {
            name = "Submarine";
            this.length = 3;
            ship = new Tile[length];
        }
    }
}
