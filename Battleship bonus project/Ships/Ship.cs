using Battleship_bonus_project.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Battleship_bonus_project.Ships
{
    internal class Ship
    {
        public string name;
        public int length;
        public Tile[] ship;
        public int horizontal = 1;
        public int vertical = 1;
        public bool rotated = false;
        public Ship()
        {

        }

        internal bool CheckIfDestroyed()
        {
            foreach(Tile tile in ship)
            {
                if(!tile.hit) { return false; }
            }
            return true;
        }

        public void DisplayShipStatus()
        {
            if (CheckIfDestroyed()) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(name);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(name);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        internal void MoveShip(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    if (horizontal < 11 - length && !rotated) { horizontal++; }
                    else if (horizontal < 10 && rotated) { horizontal++; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (horizontal > 1) { horizontal--; }
                    break;
                case ConsoleKey.UpArrow:
                    if (vertical > 1) { vertical--; }
                    break;
                case ConsoleKey.DownArrow:
                    if (vertical < 11 - length && rotated) { vertical++; }
                    else if (vertical < 10 && !rotated) { vertical++; }
                    break;
                case ConsoleKey.R:
                    if (rotated) { rotated = false; }
                    else { rotated = true; }
                    break;
            }
        }

        public void PlaceShip(Board board, int player)
        {
            bool failed = false;
            bool valid = false;
            ConsoleKeyInfo keyInfo;
            Tile[] temp = new Tile[length];
            while (valid == false)
            {
                horizontal = 1;
                vertical = 1;
                for (int i = 0; i < length; i++)
                {
                    temp[i] = board.board[vertical][horizontal + i];
                }
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Player {player}'s turn: Place your {name}");
                    Console.WriteLine("Use the arrow keys to move your ships and R to rotate them");

                    if (rotated == false)
                    {
                        if (horizontal > 11 - length) { horizontal = 11 - length; }
                        for (int i = 0; i < length; i++) { board.board[vertical][horizontal + i] = new ShipTile(); ship[i] = board.board[vertical][horizontal + i]; }
                    }
                    else
                    {
                        if (vertical > 11 - length) { vertical = 11 - length; }
                        for (int i = 0; i < length; i++) { board.board[vertical + i][horizontal] = new ShipTile(); ship[i] = board.board[vertical + i][horizontal]; }
                    }
                    board.PrintBoard();
                    if (failed)
                    {
                        Console.WriteLine("You cannot place a ship on another ship, please try again");
                        failed = false;
                    }
                    keyInfo = Console.ReadKey();
                    if (!rotated && keyInfo.Key != ConsoleKey.Enter)
                    {
                        for (int i = 0; i < length; i++) { board.board[vertical][horizontal + i] = temp[i]; }
                        MoveShip(keyInfo);
                        if (!rotated) 
                        {
                            if (horizontal > 11 - length) { horizontal = 11 - length; }
                            for (int i = 0; i < length; i++) { temp[i] = board.board[vertical][horizontal + i]; } 
                        }
                        else 
                        {
                            if (vertical > 11 - length) { vertical = 11 - length; }
                            for (int i = 0; i < length; i++) { temp[i] = board.board[vertical + i][horizontal]; } 
                        }
                    }
                    else if (rotated && keyInfo.Key != ConsoleKey.Enter)
                    {
                        for (int i = 0; i < length; i++) { board.board[vertical + i][horizontal] = temp[i]; }
                        MoveShip(keyInfo);
                        if (rotated) 
                        {
                            if (vertical > 11 - length) { vertical = 11 - length; }
                            for (int i = 0; i < length; i++) { temp[i] = board.board[vertical + i][horizontal]; } 
                        }
                        else 
                        {
                            if (horizontal > 11 - length) { horizontal = 11 - length; }
                            for (int i = 0; i < length; i++) { temp[i] = board.board[vertical][horizontal + i]; } 
                        }
                    }

                } while (keyInfo.Key != ConsoleKey.Enter);
                foreach (Tile tile in temp)
                {
                    if (!CheckValidityOfPlacement(tile)) 
                    {
                        failed = true;
                        valid = false;
                        if (!rotated) { for (int i = 0; i < length; i++) { board.board[vertical][horizontal + i] = temp[i]; } }
                        else { for (int i = 0; i < length; i++) { board.board[vertical + i][horizontal] = temp[i]; } }
                        break;
                    }
                    else { valid = true; }
                }
            }
        }

        static bool CheckValidityOfPlacement(Tile temp)
        {
            if (temp is ShipTile) { return false; }
            else { return true; }
        }
    }
}
