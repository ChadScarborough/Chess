﻿using ChessBoard.Boards;
using ChessBoard.Globals;
using static ChessBoard.Globals.Enums;
using ChessBoard.Pieces.MoveBehaviours;
using static ChessBoard.Globals.Functions;

namespace ChessBoard.Pieces
{
    public class Knight : IPiece
    {
        private IBoard _board;
        private IMoveBehaviour _moveBehaviour;

        public Enums.Color PieceColor { get; init; }
        public Enums.PieceType Type => KNIGHT;
        public Square Location { get; set; }
        public int Value => 3;

        public Knight(IBoard board, Coordinate coordinate, Color color)
        {
            _board = board;
            Location = board.GetSquareByCoordinate(coordinate);
            Location.SetPiece(this);
            PieceColor = color;
            _moveBehaviour = new KnightMoveBehaviour(_board, this);
        }

        public void Destroy()
        {
            // TODO: Add logic here
        }

        public void Move(int rank, int file)
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
            switch (PieceColor)
            {
                case WHITE:
                    return "N";
                case BLACK:
                    return "n";
                default:
                    throw new Exception("Meeeeoooooow");
            }
        }
    }
}
