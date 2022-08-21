using ChessBoard.Boards;
using ChessBoard.Pieces.MoveBehaviours;
using static ChessBoard.Globals.Enums;

namespace ChessBoard.Pieces
{
    public abstract class Pawn : IPiece
    {
        protected IBoard _board;
        protected IMoveBehaviour? _moveBehaviour;

        public abstract Color PieceColor { get; }
        public abstract Square Location { get; set; }
        public PieceType Type { get => PAWN; }

        public int Value { get => 1; }

        public Pawn(IBoard board, Coordinate coordinate)
        {
            _board = board;
        }

        public abstract void Destroy();
        public abstract void Move(int rank, int file);
    }
}