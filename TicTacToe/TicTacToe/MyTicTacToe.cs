using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    class MyTicTacToe
    {
        static int[,] board;
        string playerName;

        public MyTicTacToe(int player, string playerName)
        {
            PlayerName = playerName;
            Player = player;
            board = new int[3, 3];
        }

        public int Player { get; set; }

        public string PlayerName
        {
            get { return this.playerName; }
            set
            {
                if (value.Length > 0)
                    this.playerName = value;
                else
                {
                    while (value.Length < 1) // name cannot be empty string
                    {
                        Console.WriteLine("Invalid entry. Please re-enter player's name: ");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        public bool PlayGame()
        {
            int r = 0;
            int c = 0;

            Random rand1 = new Random();
            Random rand2 = new Random();

            if (PlayerName != "computer")//playing against human player
            {
                Console.WriteLine("Please enter where to place your symbol");
                int.TryParse(Console.ReadLine().Trim(), out r);
                int.TryParse(Console.ReadLine().Trim(), out c);
            }

            else //playing against computer
            {
                r = rand1.Next(1, 4);
                c = rand1.Next(1, 4);
            }

            while (!checkBoard(r, c))
            {
                if (PlayerName != "computer")//human player
                {
                    Console.WriteLine("You entered incorrect coordinates. Try again");
                    int.TryParse(Console.ReadLine().Trim(), out r);
                    int.TryParse(Console.ReadLine().Trim(), out c);
                }

                else
                {
                    r = rand1.Next(1, 4);
                    c = rand1.Next(1, 4);
                }
            }

            board[r - 1, c - 1] = Player;
            displayBoard();//display updated board

            if (win())
            {
                if (PlayerName.Equals("computer"))
                    Console.WriteLine("Computer Wins!!");
                else
                    Console.WriteLine("Congradulations " + PlayerName + " . You WIN!");

                return true;

            }

            else if (draw())
            {
                Console.WriteLine("It's a DRAW!!");
                return true;
            }

            return false; //not a draw and not a win
        }

        private bool win()
        {
            //check rows
            if (board[0, 0].Equals(Player) && board[0, 1].Equals(Player) && board[0, 2].Equals(Player))
                return true;
            if (board[1, 0].Equals(Player) && board[1, 1].Equals(Player) && board[1, 2].Equals(Player))
                return true;
            if (board[2, 0].Equals(Player) && board[2, 1].Equals(Player) && board[2, 2].Equals(Player))
                return true;

            //check columns
            if (board[0, 0].Equals(Player) && board[1, 0].Equals(Player) && board[2, 0].Equals(Player))
                return true;
            if (board[0, 1].Equals(Player) && board[1, 1].Equals(Player) && board[2, 1].Equals(Player))
                return true;
            if (board[0, 2].Equals(Player) && board[1, 2].Equals(Player) && board[2, 2].Equals(Player))
                return true;

            //accross
            if (board[0, 0].Equals(Player) && board[1, 1].Equals(Player) && board[2, 2].Equals(Player))
                return true;
            if (board[0, 2].Equals(Player) && board[1, 1].Equals(Player) && board[2, 0].Equals(Player))
                return true;

            return false;
        }
    

        private bool draw()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (board[r, c] != 1 && board[r, c] != 2)
                        return false; //it's not a draw
                }
            }

            return true;
        }

        private bool checkBoard(int r, int c)
        {
            bool OK = false;
            if (r > 3 || c > 3)
                return false;

            if (board[r-1, c-1] != 1 && board[r-1, c-1] != 2)
                OK = true;

            return OK;
        }

        public static void intBoard()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                    board[r, c] = 0;
            }

            displayBoard();
        }

        private static void displayBoard()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                    Console.Write(board[r, c] + " "); //0,0,0

                Console.WriteLine(); 
            }
            Console.WriteLine();
        }
    }
}
