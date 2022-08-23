using ChessBoard.Boards;

namespace ChessBoard.Pieces.MoveBehaviours
{
    public class KnightMoveBehaviour : IMoveBehaviour
    {
        private IBoard _board;
        private Knight _knight;

        public KnightMoveBehaviour(IBoard board, Knight knight)
        {
            _board = board;
            _knight = knight;
        }

        public bool CanMove(Coordinate targetLocation)
        {
            try
            {
                Coordinate currentLocation = _knight.Location.GetCoordinate();
                GuardMove(currentLocation, targetLocation);
                int rankDiff = Math.Abs(currentLocation.rank - targetLocation.rank);
                int fileDiff = Math.Abs(currentLocation.file - targetLocation.file);
                if (rankDiff + fileDiff == 3 && rankDiff * fileDiff == 2) return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        private void GuardMove(Coordinate currentLocation, Coordinate targetLocation)
        {
            if (currentLocation.Equals(targetLocation)) 
                throw new Exception("Piece cannot move to the square it already occupies");
            Square endingSquare = _board.GetSquareByCoordinate(targetLocation);
            if (endingSquare.IsOccupied() && endingSquare.OccupyingPieceColor() == _knight.PieceColor)
                throw new Exception("Cannot capture a piece of the same color");
        }
    }
}
