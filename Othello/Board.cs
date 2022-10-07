namespace Othello
{
    internal class Board
    {
        private bool?[,] board = new bool?[8, 8];

        public void Initialize()
        {
            board[3, 3] = Players.White;
            board[4, 3] = Players.Black;
            board[3, 4] = Players.Black;
            board[4, 4] = Players.White;
        }

        public void Print()
        {
            for (int x = 0; x < 8 * 2 + 1; x++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            for (int x = 0; x < 8; x++)
            {
                Console.Write("|");
                for (var y = 0; y < 8; y++)
                {
                    bool? value = board[x, y];
                    if (!value.HasValue)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(value.Value ? "O " : "X ");
                    }
                }

                Console.WriteLine("\b|");
            }

            for (int x = 0; x < 8 * 2 + 1; x++)
            {
                Console.Write("-");
            }

            Console.WriteLine();
        }
        
        private void CheckPositionBoundary(int x, int y)
        {
            if (x < 0 || x >= 8)
            {
                throw new ArgumentOutOfRangeException($"{nameof(x)} is out of range: {x}");
            }

            if (y < 0 || y >= 8)
            {
                throw new ArgumentOutOfRangeException($"{nameof(y)} is out of range: {y}");
            }
        }

        public void Set(int x, int y, bool player)
        {
            CheckPositionBoundary(x, y);

            board[x, y] = player;
        }

        public bool IsValidMove(int x, int y)
        {
            CheckPositionBoundary(x, y);

            return !board[x, y].HasValue;
        }
    }
}
