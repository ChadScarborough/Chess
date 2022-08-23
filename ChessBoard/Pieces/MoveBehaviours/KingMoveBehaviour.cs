using ChessBoard.Boards;

namespace ChessBoard.Pieces.MoveBehaviours
{
    public class KingMoveBehaviour : IMoveBehaviour
    {
        IBoard _board;
        IPiece _piece;

        public KingMoveBehaviour(IBoard board, IPiece piece)
        {
            _board = board;
            _piece = piece;
        }

        //TODO: Add logic for castling and preventing moving into or remaining in check

        public bool CanMove(Coordinate targetLocation)
        {
            try
            {
                Coordinate currentLocation = _piece.Location.GetCoordinate();
                if (currentLocation.Equals(targetLocation))
                    return false;
                if (_board.GetSquareByCoordinate(targetLocation).IsOccupied() &&
                    _board.GetSquareByCoordinate(targetLocation).OccupyingPieceColor() == _piece.PieceColor)
                    return false;
                int rankDiff = Math.Abs(currentLocation.rank - targetLocation.rank);
                int fileDiff = Math.Abs(currentLocation.rank - targetLocation.rank);
                if (rankDiff > 1 || fileDiff > 1)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
