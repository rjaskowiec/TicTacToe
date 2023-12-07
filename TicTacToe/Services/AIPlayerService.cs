using System;

namespace TicTacToe.Services
{

    public class AIPlayerService
    {
        private readonly char playerChar;

        public AIPlayerService(char playerChar) => this.playerChar = playerChar;

        public (int, int) MakeMove(char[,] board) => GetBestMove(board);

        private static (int, int) GetBestMove(char[,] board)
        {
            char aiPlayerChar = 'O';

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == '-')
                    {
                        board[row, col] = aiPlayerChar;

                        if (CheckWin(board, aiPlayerChar))
                        {
                            board[row, col] = '-';
                            return (row, col);
                        }

                        board[row, col] = '-';
                    }
                }
            }

            char humanPlayerChar = 'X';
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == '-')
                    {
                        board[row, col] = humanPlayerChar;

                        if (CheckWin(board, humanPlayerChar))
                        {
                            board[row, col] = '-';
                            return (row, col);
                        }

                        board[row, col] = '-';
                    }
                }
            }

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == '-')
                    {
                        return (row, col);
                    }
                }
            }

            return (-1, -1);
        }


        private static bool CheckWin(char[,] board, char checkChar)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == checkChar && board[i, 1] == checkChar && board[i, 2] == checkChar) ||
                    (board[0, i] == checkChar && board[1, i] == checkChar && board[2, i] == checkChar))
                {
                    return true;
                }
            }

            if ((board[0, 0] == checkChar && board[1, 1] == checkChar && board[2, 2] == checkChar) || 
                (board[0, 2] == checkChar && board[1, 1] == checkChar && board[2, 0] == checkChar))  
            {
                return true;
            }

            return false;
        }
    }
}
