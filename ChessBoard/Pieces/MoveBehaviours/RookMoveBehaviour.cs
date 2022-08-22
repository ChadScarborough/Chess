using ChessBoard.Boards;

namespace ChessBoard.Pieces.MoveBehaviours
{
    public class RookMoveBehaviour : IMoveBehaviour
    {
        private IBoard _board;
        private IPiece _piece;

        public RookMoveBehaviour(IBoard board, IPiece piece)
        {
            _board = board;
            _piece = piece;
        }

        public bool CanMove(Coordinate targetLocation)
        {
            Coordinate currentLocation = _piece.Location.GetCoordinate();
            if (currentLocation.Equals(targetLocation)) 
                throw new Exception("Piece cannot move to the square it already occupies");
            if (currentLocation.rank != targetLocation.rank && currentLocation.file != targetLocation.file)
                throw new Exception("Rooks may only move along ranks or files");
            if (_board.GetSquareByCoordinate(targetLocation).IsOccupied() && 
                _board.GetSquareByCoordinate(targetLocation).OccupyingPieceColor() == _piece.PieceColor)
                throw new Exception("Cannot capture a piece of the same color");
            if (currentLocation.rank == targetLocation.rank)
                return CanMoveAlongRank(currentLocation, targetLocation);
            if (currentLocation.file == targetLocation.file)
                return CanMoveAlongFile(currentLocation, targetLocation);
            return false;
        }

        private bool CanMoveAlongRank(Coordinate currentLocation, Coordinate targetLocation)
        {
            if (targetLocation.file > currentLocation.file)
                return CanMoveRightAlongRank(currentLocation, targetLocation);
            return CanMoveLeftAlongRank(currentLocation, targetLocation);
        }

        private bool CanMoveRightAlongRank(Coordinate currentLocation, Coordinate targetLocation)
        {
            int rank = currentLocation.rank;
            int currentFile = currentLocation.file + 1;
            int targetFile = targetLocation.file;
            while (currentFile < targetFile)
            {
                if (_board.GetSquareByCoordinate(new Coordinate(rank, currentFile)).IsOccupied())
                {
                    throw new Exception("Piece cannot move through another piece");
                }
                currentFile++;
            }
            return true;
        }

        private bool CanMoveLeftAlongRank(Coordinate currentLocation, Coordinate targetLocation)
        {
            int rank = currentLocation.rank;
            int currentFile = currentLocation.file - 1;
            int targetFile = targetLocation.file;
            while (currentFile > targetFile)
            {
                if (_board.GetSquareByCoordinate(new Coordinate(rank, currentFile)).IsOccupied())
                {
                    throw new Exception("Piece cannot move through another piece");
                }
                currentFile--;
            }
            return true;
        }

        private bool CanMoveAlongFile(Coordinate currentLocation, Coordinate targetLocation)
        {
            if (targetLocation.rank > currentLocation.rank)
                return CanMoveUpAlongFile(currentLocation, targetLocation);
            return CanMoveDownAlongFile(currentLocation, targetLocation);
        }

        private bool CanMoveUpAlongFile(Coordinate currentLocation, Coordinate targetLocation)
        {
            int file = currentLocation.file;
            int currentRank = currentLocation.rank + 1;
            int targetRank = targetLocation.rank;
            while (currentRank < targetRank)
            {
                if (_board.GetSquareByCoordinate(new Coordinate(currentRank, file)).IsOccupied())
                {
                    throw new Exception("Piece cannot move through another piece");
                }
                currentRank++;
            }
            return true;
        }

        private bool CanMoveDownAlongFile(Coordinate currentLocation, Coordinate targetLocation)
        {
            int file = currentLocation.file;
            int currentRank = currentLocation.rank - 1;
            int targetRank = targetLocation.rank;
            while (currentRank > targetRank)
            {
                if (_board.GetSquareByCoordinate(new Coordinate(currentRank, file)).IsOccupied())
                {
                    throw new Exception("Piece cannot move through another piece");
                }
                currentRank--;
            }
            return true;
        }
    }
}
