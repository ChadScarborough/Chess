using ChessGame.Games;

StandardGame game = new StandardGame();
int moveCounter = 0;
while (true)
{
    try
    {
        Console.Clear();
        Console.WriteLine(game.Board);
        string? input = Console.ReadLine();
        if (input == null) continue;
        if (moveCounter % 2 == 0)
        {
            WhiteMove(input);
            moveCounter++;
            continue;
        }
        BlackMove(input);
        moveCounter++;
    }
    catch
    {
        continue;
    }
}

void WhiteMove(string input)
{
    game.WhitePlayer.MakeMoveFromStringInput(input);
}

void BlackMove(string input)
{
    game.BlackPlayer.MakeMoveFromStringInput(input);
}