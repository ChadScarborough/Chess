using ChessBoard.Boards;

namespace ChessBoard.Pieces.MoveBehaviours
{
    public class QueenMoveBehaviour : IMoveBehaviour
    {
        private BishopMoveBehaviour _bishopMoveBehaviour;
        private RookMoveBehaviour _rookMoveBehaviour;

        public QueenMoveBehaviour(IBoard board, IPiece piece)
        {
            _bishopMoveBehaviour = new BishopMoveBehaviour(board, piece);
            _rookMoveBehaviour = new RookMoveBehaviour(board, piece);
        }

        public bool CanMove(Coordinate targetLocation)
        {
            return CanMoveAsRook(targetLocation) || CanMoveAsBishop(targetLocation);
        }

        private bool CanMoveAsRook(Coordinate targetLocation)
        {
            try
            {
                return _rookMoveBehaviour.CanMove(targetLocation);
            }
            catch
            {
                return false;
            }
        }

        private bool CanMoveAsBishop(Coordinate targetLocation)
        {
            try
            {
                return _bishopMoveBehaviour.CanMove(targetLocation);
            }
            catch
            {
                return false;
            }
        }
    }
}
