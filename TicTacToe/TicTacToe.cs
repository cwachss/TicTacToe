using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TicTacToe
    {
        //matrix of gameboard
        //gameboard is four spaces to allow for the game to be played in spaces 1-3, making it more user friendly
        private int[,] gameBoard;

        //stores winner values (either -1 or 1)
        private int winner;

        //switches between two players
        private int turn;

        public TicTacToe()
        {
            gameBoard = new int[4, 4];
            winner = 0;
            turn = 1;
        }
        
       
       //for playing game. might just put this in the main- we shall see
        public void Game()
        {
            
            //loop
            while (winner == 0 && turn < 10)
            {
                TakeTurn(turn);
                turn++;
                winner = CheckWinner(ColumnSum(), RowSum());
            }

            //display final board
           PrintBoard();
           //if x wins:
            if (winner > 0)
            {
                Console.WriteLine("X wins!");

            }
            //if O wins:
           else if (winner < 0)
            {
                Console.WriteLine("O wins!");
            }
           //if nobody wins:
            else
            {
                Console.WriteLine("Game over. No one wins.");
            }
           

        }

        //allows players to take turns
        public void TakeTurn(int whoseTurn)
        {

            /*
             * print board
             * ask what spot
             * choose spot
             * see if it's valid- if invalid, allow to go back (see airline program)
             * if valid, fill spot with whose turn it is
             * check for winner(column or row == 3 or -3) into an if statement- if one won, break "Whose turn"
             * switch persons turn (increment turn, x
             * 
             */

            //display board so the player can choose a spot
            PrintBoard();
            //tells player to first enter row number then column number
            Console.WriteLine("To choose a spot, enter which row and then enter which column");
            Console.WriteLine("Row:");
            int rowNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Column:");
            int colNum = int.Parse(Console.ReadLine());
            //counter is just to allow player to pick a new spot if their first one doesn't work
            int counter = whoseTurn;

            //while the counter is still the same (meaning until they choose a valid spot)
            while (counter == whoseTurn)
            {
                //if its a valid spot
                if (gameBoard[rowNum, colNum] == 0)
                {
                    //depending on whose turn it is, put 1 or -1 in that spot. 1 = x, -1 is O. raise counter to indicate turn successful.
                    if (whoseTurn % 2 == 0)
                    {

                        gameBoard[rowNum, colNum] = -1;

                        counter++;
                    }
                    else
                    {

                        gameBoard[rowNum, colNum] = 1;
                        counter++;
                    }
                }
                //allow player to choose new spot
                else
                {
                    Console.WriteLine("That spot is taken. Please enter a new row and column number.");
                    Console.WriteLine("Row:");
                    rowNum = int.Parse(Console.ReadLine());
                    Console.WriteLine("Column:");
                    colNum = int.Parse(Console.ReadLine());
                }
            }
        }

        //displays board so players can choose where to go
        public void PrintBoard()
        {
            //starts at 1 to allow user to input 1-3 instead of 0-2 (more user friendly)
            for (int row = 1; row < gameBoard.GetLength(0); row++)
            {
                for (int column = 1; column < gameBoard.GetLength(1); column++)
                {
                    if (gameBoard[row, column] == -1)
                    {
                        Console.Write("O ");
                    }
                    else if (gameBoard[row, column] == 1)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("_ ");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        //make sum of columns to send to winner
        public int ColumnSum()
        {
            int total = 0;

            for (int column = 1; column < gameBoard.GetLength(1); column++)
            {
                
                for (int row = 1; row < gameBoard.GetLength(0); row++)
                {
                    total += gameBoard[row, column];
                }

                //if a winner is found, stop running code and return 3 or -3
                if (total == 3 || total == -3)
                {
                    break;
                }
                total = 0;

            }


            return total;
        }
        
        //make some of rows to 
        public int RowSum()
        {
            int total = 0;

            for (int row = 1; row < gameBoard.GetLength(0); row++)
            {

                for (int column = 1; column < gameBoard.GetLength(1); column++)
                {
                    total += gameBoard[row, column];
                }

                //if a winner is found, stop running code and return 3 or -3
                if (total == 3 || total == -3)
                {
                    break;
                }
                total = 0;
            }

            return total;
        }

        //checks for a winner by receiving the column sum and the row sum and seeing if they equal 3 or -3
        public int CheckWinner(int total1, int total2)
        {
            int winner = 0;
            if (total1 == 3 || total2 == 3)
            {
                winner = 1;
            }
            if (total1 == -3 || total2 == -3)
            {
                winner = -1;
            }
            return winner;
        }
    }

}
