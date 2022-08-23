using ChessBoard.Pieces;
using ChessBoard.Boards;
using static ChessGame.Globals.PieceSetups;

namespace ChessGame.Players
{
    public class StandardBlackPlayer : Player
    {
        public override List<IPiece> Pieces { get; init; }

        public StandardBlackPlayer(IBoard board) : base(board)
        {
            Pieces = new List<IPiece>();
            Setup();
        }

        public override void Setup()
        {
            StandardBlackSetup(this, _board);
        }
    }
}
