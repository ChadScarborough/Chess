﻿using ChessBoard.Boards;
using static ChessBoard.Globals.Enums;

namespace ChessBoard.Pieces.MoveBehaviours
{
    public class WhitePawnMoveBehaviour : IMoveBehaviour
    {
        private IBoard _board;
        private Pawn _pawn;

        public WhitePawnMoveBehaviour(IBoard board, Pawn pawn)
        {
            _board = board;
            _pawn = pawn;
        }

        public bool CanMove(Coordinate targetLocation)
        {
            try
            {
                Coordinate currentLocation = _pawn.Location.GetCoordinate();
                if (currentLocation.Equals(targetLocation))
                    throw new Exception("Piece cannot move to the square it already occupies");
                Square targetSquare = _board.GetSquareByCoordinate(targetLocation);
                if (targetSquare.IsOccupied())
                {
                    return TryCapture(currentLocation, targetLocation);
                }
                if (currentLocation.rank == 1)
                {
                    return SecondRankMove(currentLocation, targetLocation);
                }
                return StandardMove(currentLocation, targetLocation);
            }
            catch
            {
                return false;
            }
        }

        private bool TryCapture(Coordinate currentLocation, Coordinate targetLocation)
        {
            GuardTryCapture(targetLocation);
            return Capture(currentLocation, targetLocation);
        }

        private void GuardTryCapture(Coordinate targetLocation)
        {
            Square targetSquare = _board.GetSquareByCoordinate(targetLocation);
            if (targetSquare.OccupyingPieceColor() == WHITE)
                throw new Exception("Target square is occupied by a piece of the same color");
        }

        private bool Capture(Coordinate currentLocation, Coordinate targetLocation)
        {
            GuardCapture(currentLocation, targetLocation);
            return true;
        }

        private void GuardCapture(Coordinate currentLocation, Coordinate targetLocation)
        {
            if (targetLocation.rank != currentLocation.rank + 1)
                throw new Exception("Cannot capture more than one rank ahead");
            if ((targetLocation.file != currentLocation.file + 1) &&
                (targetLocation.file != currentLocation.file - 1))
                throw new Exception("Pawns may only capture diagonally");
        }

        private bool SecondRankMove(Coordinate currentLocation, Coordinate targetLocation)
        {
            GuardSecondRankMove(currentLocation, targetLocation);
            return true;
        }

        private void GuardSecondRankMove(Coordinate currentLocation, Coordinate targetLocation)
        {
            if (currentLocation.file != targetLocation.file)
                throw new Exception("Pawn must move directly forward, unless capturing");
            if (targetLocation.rank != 2 && targetLocation.rank != 3)
                throw new Exception("Pawn may move at most two squares forward");
            if (targetLocation.rank == 3 && InBetweenSquareIsOccupied(currentLocation))
                throw new Exception("Pawn cannot move through another piece");
        }

        private bool InBetweenSquareIsOccupied(Coordinate currentLocation)
        {
            Square inBetweenSquare = _board.GetSquareByCoordinate(new Coordinate(5, currentLocation.file));
            return inBetweenSquare.IsOccupied();
        }

        private bool StandardMove(Coordinate currentLocation, Coordinate targetLocation)
        {
            GuardStandardMove(currentLocation, targetLocation);
            return true;
        }

        private void GuardStandardMove(Coordinate currentLocation, Coordinate targetLocation)
        {
            if (currentLocation.file != targetLocation.file)
                throw new Exception("Pawn must move directly forward, unless capturing");
            if (targetLocation.rank != currentLocation.rank + 1)
                throw new Exception("Pawn may only move one space forward");
        }
    }
}
