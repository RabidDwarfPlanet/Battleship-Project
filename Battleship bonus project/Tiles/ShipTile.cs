using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project.Tiles
{
    internal class ShipTile : Tile
    {
        public ShipTile()
        {
            tile = "[■]";
        }

        public override void displayTile()
        {
            if (!hit) { Console.ForegroundColor = ConsoleColor.Green; } 
            else { Console.ForegroundColor = ConsoleColor.Red; }
            base.displayTile();
        }
    }
}
