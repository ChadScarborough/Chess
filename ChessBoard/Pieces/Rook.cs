using ChessBoard.Boards;
using static ChessBoard.Globals.Functions;
using static ChessBoard.Globals.Enums;
using ChessBoard.Pieces.MoveBehaviours;

namespace ChessBoard.Pieces
{
    public class Rook : IPiece
    {
        private IBoard _board;
        private IMoveBehaviour _moveBehaviour;

        public Color PieceColor { get; }
        public PieceType Type => ROOK;
        public Square Location { get; set; }
        public int Value => 5;

        public Rook(IBoard board, Coordinate coordinate, Color color)
        {
            _board = board;
            Location = board.GetSquareByCoordinate(coordinate);
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
            try
            {
                TryMove(rank, file);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void TryMove(int rank, int file)
        {
            GuardAgainstOffBoardMoves(rank, file);
            Coordinate targetCoordinate = new Coordinate(rank, file);
            if (_moveBehaviour.CanMove(targetCoordinate))
            {
                _board.MovePiece(this, targetCoordinate);
            }
        }

        public override string ToString()
        {
            switch (PieceColor)
            {
                case WHITE:
                    return "R";
                case BLACK:
                    return "r";
                default:
                    throw new Exception("Meeeeoooooow");
            }
        }
    }
}
