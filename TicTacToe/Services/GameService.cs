namespace TicTacToe.Services
{
    public enum GameStatus
    {
        InProgress,
        PlayerXWins,
        PlayerOWins,
        Draw
    }

    public class GameService
    {
        private char[,] board;
        private char currentPlayer;

        public GameService()
        {
            board = new char[3, 3];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            currentPlayer = 'X';

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = '-';
                }
            }
        }

        public void ResetGame() => InitializeBoard();

        public bool MakeMove(int row, int col)
        {
            if (row < 0 || row >= 3 || col < 0 || col >= 3 || board[row, col] != '-')
            {
                return false;
            }

            board[row, col] = currentPlayer;
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            return true;
        }

        public GameStatus CheckGameStatus()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] != '-' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    return (GameStatus)((int)Enum.Parse(typeof(GameStatus), $"Player{board[i, 0]}Wins"));
                }

                if (board[0, i] != '-' && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    return (GameStatus)((int)Enum.Parse(typeof(GameStatus), $"Player{board[0, i]}Wins"));
                }
            }

            if (board[0, 0] != '-' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return (GameStatus)((int)Enum.Parse(typeof(GameStatus), $"Player{board[0, 0]}Wins"));
            }

            if (board[0, 2] != '-' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return (GameStatus)((int)Enum.Parse(typeof(GameStatus), $"Player{board[0, 2]}Wins"));
            }

            bool isBoardFull = true;
            foreach (var cell in board)
            {
                if (cell == '-')
                {
                    isBoardFull = false;
                    break;
                }
            }

            if (isBoardFull)
            {
                return GameStatus.Draw;
            }

            return GameStatus.InProgress;
        }

        public char[,] GetBoardState() => board;

        public char GetCurrentPlayer() => currentPlayer;
    }

}
