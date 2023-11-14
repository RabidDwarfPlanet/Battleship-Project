using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project.Tiles
{
    internal class EmptyTile : Tile
    {
        public EmptyTile()
        {
            tile = "[~]";
        }

        public override void displayTile()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.displayTile();
        }
    }
}
