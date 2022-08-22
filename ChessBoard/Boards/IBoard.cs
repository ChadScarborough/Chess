using ChessBoard.Pieces;

namespace ChessBoard.Boards
{
    public interface IBoard
    {
        Square GetSquareByCoordinate(Coordinate coordinate);
        Square GetSquareByCoordinate(int rank, int file);
        string ToString();
        void AddPiece(IPiece piece, Coordinate coordinate);
        void RemovePiece(Coordinate coordinate);
        void RemovePiece(int rank, int file);
        void MovePiece(IPiece piece, Square square);
        void MovePiece(IPiece piece, Coordinate coordinate);
    }
}