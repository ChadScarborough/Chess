using ChessBoard.Boards;
using ChessBoard.Pieces.MoveBehaviours;
using static ChessBoard.Globals.Enums;

namespace ChessBoard.Pieces
{
    public class BlackPawn : IPiece
    {
        private IBoard _board;
        private IMoveBehaviour _moveBehaviour;
        public Color PieceColor { get => BLACK; }
        public PieceType Type { get => PAWN; }
        public Square Location { get; set; }

        public BlackPawn(IBoard board, Coordinate coordinate)
        {
            _board = board;
            _moveBehaviour = new BlackPawnMoveBehaviour(this, _board);
            Location = board.GetSquareByCoordinate(coordinate);
            Location.SetPiece(this);
        }

        public void Destroy()
        {
            //TODO: Maybe include some logic here?
        }

        public void Move(int rank, int file)
        {
            try
            {
                _moveBehaviour.Move(Location.GetCoordinate(), new Coordinate(rank, file));
                // Change turns
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public override string ToString()
        {
            return "p";
        }
    }
}
