using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; // The game board
        static char currentPlayer = 'X'; // The player who is currently playing

        static void Main(string[] args)
        {
            InitializeBoard(); // Set up the board

            bool gameOver = false;

            while (!gameOver)
            {
                DisplayBoard(); // Display the current state of the board

                Console.WriteLine($"Player {currentPlayer}'s turn. Enter row and column for your move (e.g., 1 2): ");
                string[] input = Console.ReadLine().Split(' ');

                if (input.Length != 2 || !int.TryParse(input[0], out int row) || !int.TryParse(input[1], out int col))
                {
                    Console.WriteLine("Invalid input format. Please try again.");
                    continue;
                }

                if (!IsValidMove(row, col))
                {
                    Console.WriteLine("Invalid move. Please try again.");
                    continue;
                }

                MakeMove(row, col); // Apply the move

                if (CheckForWin())
                {
                    DisplayBoard();
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    gameOver = true;
                }
                else if (IsBoardFull())
                {
                    DisplayBoard();
                    Console.WriteLine("It's a draw!");
                    gameOver = true;
                }

                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X'; // Switch players
            }
        }

        // Initialize the game board
        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        // Display the game board
        static void DisplayBoard()
        {
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Check if a move is valid
        static bool IsValidMove(int row, int col)
        {
            return (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == '-');
        }

        // Apply a move
        static void MakeMove(int row, int col)
        {
            board[row, col] = currentPlayer;
        }

        // Check for a win
        static bool CheckForWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                    return true; // Horizontal win
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                    return true; // Vertical win
            }
            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                return true; // Diagonal win
            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                return true; // Diagonal win
            return false;
        }

        // Check if the board is full
        static bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                        return false;
                }
            }
            return true;
        }
    }
}
