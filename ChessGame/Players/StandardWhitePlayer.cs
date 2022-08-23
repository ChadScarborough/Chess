using ChessBoard.Pieces;
using ChessBoard.Boards;
using static ChessGame.Globals.PieceSetups;

namespace ChessGame.Players
{
    public class StandardWhitePlayer : Player
    {
        public override List<IPiece> Pieces { get; init; }

        public StandardWhitePlayer(IBoard board) : base(board)
        {
            Pieces = new List<IPiece>();
            Setup();
        }

        public override void Setup()
        {
            StandardWhiteSetup(this, _board);
        }
    }
}
