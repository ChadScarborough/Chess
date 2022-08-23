using static ChessBoard.Globals.Enums;
using ChessBoard.Boards;

namespace ChessBoard.Pieces
{
    public interface IPiece
    {
        public Color PieceColor { get; }
        public PieceType Type { get; }
        public Square Location { get; set; }
        public int Value { get; }

        public void Move(int rank, int file);
        public bool CanMove(int rank, int file);
        public void Destroy();
    }
}
