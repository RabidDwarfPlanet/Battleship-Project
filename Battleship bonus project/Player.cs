using Battleship_bonus_project.Ships;
using Battleship_bonus_project.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project
{
    internal class Player
    {
        public PatrolBoat patrolBoat = new PatrolBoat();
        public Cruiser cruiser = new Cruiser();
        public Submarine submarine = new Submarine();
        public Battleship battleship = new Battleship();
        public Aircraft aircraft = new Aircraft();
        public Ship[] fleet = new Ship[5];
        public Board ships = new Board();
        public Board shots = new Board();
        public int playerNumber;

        public Player(int playerNumber)
        {
            PatrolBoat patrolBoat = new PatrolBoat(); fleet[0] = patrolBoat;
            Cruiser cruiser = new Cruiser(); fleet[1] = cruiser;
            Submarine submarine = new Submarine(); fleet[2] = submarine;
            Battleship battleship = new Battleship(); fleet[3] = battleship;
            Aircraft aircraft = new Aircraft(); fleet[4] = aircraft;
            this.playerNumber = playerNumber;
            ships.SetUpBoard();
            shots.SetUpBoard();
        }

        public void PlaceFleet()
        {
            foreach(Ship ship in fleet)
            {
                ship.PlaceShip(ships, playerNumber);
            }
        }

        public bool DetectLoss()
        {
            foreach(Ship ship in fleet)
            {
                if (!ship.CheckIfDestroyed()) { return false; }
            }
            return true;
        }
        internal void DisplayShipStatuses(Player opponent)
        {
            Console.WriteLine();
            Console.Write("Your ships:");
            Console.SetCursorPosition(20, Console.CursorTop);
            Console.Write("Opponent ships:");
            Console.WriteLine();
            for(int i = 0; i < 5; i++)
            {
                fleet[i].DisplayShipStatus();
                Console.SetCursorPosition(20, Console.CursorTop);
                opponent.fleet[i].DisplayShipStatus();
                Console.WriteLine();
            }
        }
        public void Aim(Player opponent)
        {
            int horizontal = 5;
            int vertical = 5;
            Tile temp = shots.board[vertical][horizontal];
            ConsoleKeyInfo keyInfo = default;
            do
            {
                Console.Clear();
                shots.board[vertical][horizontal] = new Aim();
                shots.PrintBoard();
                Console.WriteLine();
                ships.PrintBoard();
                DisplayShipStatuses(opponent);
                keyInfo = Console.ReadKey();
                shots.board[vertical][horizontal] = temp;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (horizontal < 10) { horizontal++; }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (horizontal > 1) { horizontal--; }
                        break;
                    case ConsoleKey.UpArrow:
                        if (vertical > 1) { vertical--; }
                        break;
                    case ConsoleKey.DownArrow:
                        if (vertical < 10) { vertical++; }
                        break;
                }
                temp = shots.board[vertical][horizontal];
                
            } while (keyInfo.Key != ConsoleKey.Enter);
            bool hit = CheckIfHit(opponent.ships, horizontal, vertical);
            Console.Clear();
            if (hit)
            {
                shots.board[vertical][horizontal] = new Hit();
                shots.PrintBoard();
                Console.WriteLine("Your shot was a hit");
                opponent.ships.board[vertical][horizontal].hit = true;
            }
            else 
            {
                shots.board[vertical][horizontal] = new Miss();
                shots.PrintBoard();
                Console.WriteLine("Your shot was a miss");
                
            }
            ships.PrintBoard();
            DisplayShipStatuses(opponent);
            Console.ReadKey();
        }   
        

        internal bool CheckIfHit(Board board, int horizontal, int vertical)
        {
            if (board.board[vertical][horizontal] is ShipTile) { return true; }
            else { return false; }
        } 
    }
}
