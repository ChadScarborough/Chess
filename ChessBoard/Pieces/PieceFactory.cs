using static ChessBoard.Globals.Enums;
using ChessBoard.Boards;

namespace ChessBoard.Pieces
{
    public static class PieceFactory
    {
        public static IPiece CreatePiece(Color color, PieceType pieceType, IBoard board, Coordinate coordinate)
        {
            switch (pieceType)
            {
                case PAWN:
                    if(color == WHITE)
                    {
                        return new WhitePawn(board, coordinate);
                    }
                    return new BlackPawn(board, coordinate);
                case KNIGHT:
                    return new Knight(board, coordinate, color);
                case BISHOP:
                    return new Bishop(board, coordinate, color);
                case ROOK:
                    return new Rook(board, coordinate, color);
                case QUEEN:
                    return new Queen(board, coordinate, color);
                default:
                    throw new Exception("Meow meow problem meow");
            }
        }
    }
}
