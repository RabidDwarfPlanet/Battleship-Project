using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project.Tiles
{
    internal class Display : Tile
    {
        public Display(string input)
        {
            tile = $"[{input}]";
        }

        public override void displayTile()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            base.displayTile();
        }
    }
}
