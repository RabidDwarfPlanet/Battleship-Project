using Battleship_bonus_project.Tiles;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project
{
    internal class Board
    {
        public List<Tile[]> board = new List<Tile[]>();
        Tile[] DisplayLine = new Tile[11];


        public Board()
        {

            board.Add(DisplayLine);
            for(int i = 0; i < 10; i++)
            {
                Tile[] line = new Tile[11];
                board.Add(line);
            }
        }

        public void SetUpDisplayLine(Tile[] line)
        {
            for(int i = 0; i < 11; i++)
            {
                if (i == 0)
                {
                    Display Emptytile = new Display(" ");
                    line[i] = Emptytile;
                }
                else if (i == 10)
                {
                    Display tile = new Display("0");
                    line[i] = tile;
                }
                else
                {
                    Display tile = new Display($"{i}");
                    line[i] = tile;
                }
            }
        }
        public void SetUpLines(Tile[] line, int letter)
        {
            List<string> letters = new List<string> { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
            for (int i = 0; i < 11; i++)
            { 
                if(i == 0) 
                {
                    Display display = new Display(letters[letter]);
                    line[i] = display; 
                }
                else 
                {
                    EmptyTile empty = new EmptyTile();
                    line[i] = empty ; 
                }
                
            }
        }

        public void SetUpBoard()
        {
            int letter = 0;
            foreach (Tile[] line in board)
            {
                if (line == DisplayLine)
                {
                    SetUpDisplayLine(line);
                }
                else
                {
                    SetUpLines(line, letter);
                    letter++;
                } 
            }
        }

        public void PrintBoard()
        {
            foreach (Tile[] line in board)
            {
                foreach(Tile tile in line)
                {
                    tile.displayTile();
                }
                Console.Write("\n");
            }
        }
    }
}
