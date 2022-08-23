using ChessGame.Players;
using ChessBoard.Boards;

namespace ChessGame.Games
{
    public class StandardGame
    {
        public Player WhitePlayer { get; init; }
        public Player BlackPlayer { get; init; }
        public IBoard Board { get; init; }

        public StandardGame()
        {
            Board = new StandardBoard();
            WhitePlayer = new StandardWhitePlayer(Board);
            BlackPlayer = new StandardBlackPlayer(Board);
        }
    }
}
