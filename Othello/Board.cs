namespace Othello
{
    internal class Board
    {
        private bool?[,] board = new bool?[8, 8];

        public void Print()
        {
            for (int x = 0; x < 8; x++)
            {
                for (var y = 0; y < 8; y++)
                {
                    bool? value = board[x, y];
                    if (!value.HasValue)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write(value.Value ? "O " : "X ");
                    }
                }

                Console.WriteLine();
            }
        }
        
        private void CheckPositionBoundary(int x, iny y)
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
