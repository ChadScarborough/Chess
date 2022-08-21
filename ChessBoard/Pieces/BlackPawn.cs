using ChessBoard.Boards;
using ChessBoard.Pieces.MoveBehaviours;
using static ChessBoard.Globals.Enums;
using static ChessBoard.Globals.Functions;

namespace ChessBoard.Pieces
{
    public class BlackPawn : Pawn
    {
        public override Color PieceColor { get => BLACK; }
        public override Square Location { get; set; }

        public BlackPawn(IBoard board, Coordinate coordinate) : base(board, coordinate)
        {
            _moveBehaviour = new BlackPawnMoveBehaviour(_board, this);
            Location = board.GetSquareByCoordinate(coordinate);
            Location.SetPiece(this);
        }

        public override void Destroy()
        {
            //TODO: Maybe include some logic here?
        }

        public override void Move(int rank, int file)
        {
            try
            {
                TryMove(rank, file);
            }
            catch (Exception ex)
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
            return "p";
        }
    }
}
