using ChessBoard.Boards;
using static ChessBoard.Globals.Enums;

namespace ChessBoard.Pieces.MoveBehaviours
{
    internal class BlackPawnMoveBehaviour : IMoveBehaviour
    {
        private readonly IPiece piece;
        private readonly IBoard board;

        public BlackPawnMoveBehaviour(IPiece piece, IBoard board)
        {
            this.piece = piece;
            this.board = board;
        }

        public void Move(Coordinate startingLocation, Coordinate endingLocation)
        {
            if (startingLocation.Equals(endingLocation)) return;
            Square endingSquare = board.GetSquareByCoordinate(endingLocation);
            if (endingSquare.IsOccupied())
            {
                TryCapture(startingLocation, endingLocation);
                return;
            }
            if (startingLocation.rank == 6)
            {
                SeventhRankMove(startingLocation, endingLocation);
                return;
            }
            StandardMove(startingLocation, endingLocation);
        }

        private void TryCapture(Coordinate startingLocation, Coordinate endingLocation)
        {
            GuardTryCapture(endingLocation);
            Capture(startingLocation, endingLocation);
        }

        private void GuardTryCapture(Coordinate endingLocation)
        {
            Square endingSquare = board.GetSquareByCoordinate(endingLocation);
            if (endingSquare.OccupyingPieceColor() == BLACK)
                throw new Exception("Target square is occupied by a piece of the same color");
        }

        private void Capture(Coordinate startingLocation, Coordinate endingLocation)
        {
            GuardCapture(startingLocation, endingLocation);
            MovePiece(startingLocation, endingLocation);
        }

        private void MovePiece(Coordinate startingLocation, Coordinate endingLocation)
        {
            Square endingSquare = board.GetSquareByCoordinate(endingLocation);
            Square startingSquare = board.GetSquareByCoordinate(startingLocation);
            endingSquare.SetPiece(piece);
            startingSquare.ClearPiece();
        }

        private void GuardCapture(Coordinate startingLocation, Coordinate endingLocation)
        {
            if (endingLocation.rank != startingLocation.rank - 1)
                throw new Exception("Cannot capture more than one rank ahead");
            if ((endingLocation.file != startingLocation.file + 1) &&
                (endingLocation.file != startingLocation.file - 1))
                throw new Exception("Pawns may only capture diagonally");
        }

        private void SeventhRankMove(Coordinate startingLocation, Coordinate endingLocation)
        {
            GuardSeventhRankMove(startingLocation, endingLocation);
            MovePiece(startingLocation, endingLocation);
        }

        private void GuardSeventhRankMove(Coordinate startingLocation, Coordinate endingLocation)
        {
            if (startingLocation.file != endingLocation.file)
                throw new Exception("Pawn must move directly forward, unless capturing");
            if (endingLocation.rank != 5 && endingLocation.rank != 4)
                throw new Exception("Pawn may move at most two squares forward");
            if (endingLocation.rank == 4 && InBetweenSquareIsOccupied(board, startingLocation))
                throw new Exception("Pawn cannot move through another piece");
        }

        private bool InBetweenSquareIsOccupied(IBoard board, Coordinate startingLocation)
        {
            Square inBetweenSquare = board.GetSquareByCoordinate(new Coordinate(5, startingLocation.file));
            return inBetweenSquare.IsOccupied();
        }

        private void StandardMove(Coordinate startingLocation, Coordinate endingLocation)
        {
            GuardStandardMove(startingLocation, endingLocation);
            MovePiece(startingLocation, endingLocation);
        }

        private void GuardStandardMove(Coordinate startingLocation, Coordinate endingLocation)
        {
            if (startingLocation.file != endingLocation.file)
                throw new Exception("Pawn must move directly forward, unless capturing");
            if (endingLocation.rank != startingLocation.rank - 1)
                throw new Exception("Pawn may only move one space forward");
        }
    }
}
