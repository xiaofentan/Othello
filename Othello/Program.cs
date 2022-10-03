using Othello;

Board board = new Board();
for (int x = 0; x < 8; x++)
{
    for (int y = 0; y < 8; y++)
    {
        board.Set(x, y, (x + y) % 2 == 0 ? Players.Black : Players.White);
    }
}

board.Print();