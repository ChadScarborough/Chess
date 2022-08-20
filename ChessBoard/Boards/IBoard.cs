using ChessBoard.Pieces;

namespace ChessBoard.Boards
{
    public interface IBoard
    {
        Square GetSquareByCoordinate(Coordinate coordinate);
        string ToString();
        void AddPiece(IPiece piece, Coordinate coordinate);
        void RemovePiece(Coordinate coordinate);
        void RemovePiece(int rank, int file);
    }
}