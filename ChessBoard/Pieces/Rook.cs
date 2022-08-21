using ChessBoard.Boards;
using ChessBoard.Globals;
using static ChessBoard.Globals.Enums;
using ChessBoard.Pieces.MoveBehaviours;

namespace ChessBoard.Pieces
{
    public class Rook : IPiece
    {
        private IBoard _board;
        private IMoveBehaviour _moveBehaviour;

        public Enums.Color PieceColor { get; }
        public Enums.PieceType Type => ROOK;
        public Square Location { get; set; }
        public int Value => 5;

        public Rook(IBoard board, Coordinate coordinate, Color color)
        {
            _board = board;
            board.AddPiece(this, coordinate);
            PieceColor = color;
            _moveBehaviour = new RookMoveBehaviour(_board, this);
        }

        public void Destroy()
        {
            // TODO: Add logic, I guess
        }

        public void Move(int rank, int file)
        {
            
        }
    }
}
