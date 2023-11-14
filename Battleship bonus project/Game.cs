using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_bonus_project
{
    internal class Game
    {
        public Player playerOne = new Player(1);
        public Player playerTwo = new Player(2);
        public Game()
        {
        }

        internal void Welcome()
        {
            Console.WriteLine("Welcome to battle ship!");
            Console.WriteLine("The goal of the game is to find and destroy all of your opponents ships");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        internal void VictoryMessage()
        {
            int winner = 0;
            int loser = 0;
            if (playerOne.DetectLoss()) { winner = playerTwo.playerNumber; loser = playerOne.playerNumber; }
            else if (playerTwo.DetectLoss()) { winner = playerOne.playerNumber; loser = playerTwo.playerNumber; }
            Console.Clear();
            Console.WriteLine($"All of player {loser}'s ships have been destroyed, therefor player {winner} is the winner!");
        }

        public void RunGame()
        {
            Welcome();
            playerOne.PlaceFleet();
            playerTwo.PlaceFleet();
            while(!playerOne.DetectLoss() && !playerTwo.DetectLoss())
            {
                playerOne.Aim(playerTwo);
                if (!playerTwo.DetectLoss())
                {
                    playerTwo.Aim(playerOne);
                }
            }
            VictoryMessage();
        }
    }
}
