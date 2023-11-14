using Battleship_bonus_project.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project.Ships
{
    internal class PatrolBoat : Ship
    {
        public PatrolBoat()
        {
            name = "Patrol Boat";
            this.length = 2;
            ship = new Tile[length];
        }
        
    }
}
