using ChessBoard.Pieces;
using static ChessBoard.Globals.Enums;

namespace ChessBoard.Boards
{
    public class Square
    {
        private readonly Coordinate _coordinate;
        private IPiece? _piece;
        private IBoard _board;

        public Square(Coordinate coordinate, IBoard board)
        {
            _coordinate = coordinate;
            _board = board;
        }

        public int GetRank()
        {
            return _coordinate.rank;
        }

        public int GetFile()
        {
            return _coordinate.file;
        }

        public Coordinate GetCoordinate()
        {
            return _coordinate;
        }

        public IPiece? GetPiece()
        {
            return _piece;
        }

        public void SetPiece(IPiece piece)
        {
            piece.Location.ClearPiece();
            if(_piece != null)
            {
                _piece.Destroy();
            }
            _piece = piece;
            _piece.Location = this;
        }

        public bool IsOccupied()
        {
            return _piece != null;
        }

        public Color? OccupyingPieceColor()
        {
            if (IsOccupied() == false) return null;
            return _piece.PieceColor;
        }  

        public override string ToString()
        {
            if (_piece != null) 
                return _piece.ToString();
            return "_";
        }

        public void ClearPiece()
        {
            _piece = null;
        }
    }

    public struct Coordinate
    {
        public readonly int rank;
        public readonly int file;

        public Coordinate(int rank, int file)
        {
            CheckForValidValues(rank, file);
            this.rank = rank;
            this.file = file;
        }

        private static void CheckForValidValues(int rank, int file)
        {
            if (rank < 0 || rank >= 8 || file < 0 || file >= 8)
                throw new IndexOutOfRangeException(
                    $"Only values from 0 to 7 allowed. " +
                    $"You supplied {rank} and {file}.");
        }
    }
}
