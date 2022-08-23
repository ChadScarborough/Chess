using ChessBoard.Boards;

namespace ChessBoard.Pieces.MoveBehaviours
{
    public class BishopMoveBehaviour : IMoveBehaviour
    {
        private readonly IBoard _board;
        private readonly IPiece _piece;

        public BishopMoveBehaviour(IBoard board, IPiece piece)
        {
            _board = board;
            _piece = piece;
        }

        public bool CanMove(Coordinate targetLocation)
        {
            Coordinate currentLocation = _piece.Location.GetCoordinate();
            if (currentLocation.Equals(targetLocation))
                return false;
            if (_board.GetSquareByCoordinate(targetLocation).IsOccupied() &&
                _board.GetSquareByCoordinate(targetLocation).OccupyingPieceColor() == _piece.PieceColor)
                return false;
            int rankDiff = Math.Abs(currentLocation.rank - targetLocation.rank);
            int fileDiff = Math.Abs(currentLocation.file - targetLocation.file);
            if (rankDiff != fileDiff)
                return false;
            if (targetLocation.rank > currentLocation.rank)
                return CanMoveUpAlongDiagonal(currentLocation, targetLocation);
            if (targetLocation.rank < currentLocation.rank)
                return CanMoveDownAlongDiagonal(currentLocation, targetLocation);
            return false;
        }

        private bool CanMoveUpAlongDiagonal(Coordinate currentLocation, Coordinate targetLocation)
        {
            if (targetLocation.file > currentLocation.file)
                return CanMoveUpAlongPositiveDiagonal(currentLocation, targetLocation);
            return CanMoveUpAlongNegativeDiagonal(currentLocation, targetLocation);
        }

        private bool CanMoveUpAlongPositiveDiagonal(Coordinate currentLocation, Coordinate targetLocation)
        {
            int currentRank = currentLocation.rank + 1;
            int currentFile = currentLocation.file + 1;
            while (currentRank < targetLocation.rank && currentFile < targetLocation.file)
            {
                if (_board.GetSquareByCoordinate(currentRank, currentFile).IsOccupied())
                    return false;
                currentRank++;
                currentFile++;
            }
            return true;
        }

        private bool CanMoveUpAlongNegativeDiagonal(Coordinate currentLocation, Coordinate targetLocation)
        {
            int currentRank = currentLocation.rank + 1;
            int currentFile = currentLocation.file - 1;
            while (currentRank < targetLocation.rank && currentFile > targetLocation.file)
            {
                if (_board.GetSquareByCoordinate(currentRank, currentFile).IsOccupied())
                    return false;
                currentRank++;
                currentFile--;
            }
            return true;
        }

        private bool CanMoveDownAlongDiagonal(Coordinate currentLocation, Coordinate targetLocation)
        {
            if (targetLocation.file > currentLocation.file)
                return CanMoveDownAlongNegativeDiagonal(currentLocation, targetLocation);
            return CanMoveDownAlongPositiveDiagonal(currentLocation, targetLocation);
        }

        private bool CanMoveDownAlongNegativeDiagonal(Coordinate currentLocation, Coordinate targetLocation)
        {
            int currentRank = currentLocation.rank - 1;
            int currentFile = currentLocation.file + 1;
            while (currentRank > targetLocation.rank && currentFile < targetLocation.file)
            {
                if (_board.GetSquareByCoordinate(currentRank, currentFile).IsOccupied())
                    return false;
                currentRank--;
                currentFile++;
            }
            return true;
        }

        private bool CanMoveDownAlongPositiveDiagonal(Coordinate currentLocation, Coordinate targetLocation)
        {
            int currentRank = currentLocation.rank - 1;
            int currentFile = currentLocation.file - 1;
            while(currentRank > targetLocation.rank && currentFile > targetLocation.file)
            {
                if (_board.GetSquareByCoordinate(currentRank, currentFile).IsOccupied())
                    return false;
                currentRank--;
                currentFile--;
            }
            return true;
        }
    }
}
