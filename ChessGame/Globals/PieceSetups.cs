using ChessBoard.Pieces;
using static ChessBoard.Pieces.PieceFactory;
using static ChessBoard.Globals.Enums;
using ChessBoard.Boards;
using ChessGame.Players;

namespace ChessGame.Globals
{
    public static class PieceSetups
    {
        public static void StandardWhiteSetup(Player player, IBoard board)
        {
            for(int i = 0; i <= 7; i++)
            {
                AddNewPiece(player, board, WHITE, PAWN, new Coordinate(1, i));
            }
            AddNewPiece(player, board, WHITE, ROOK, new Coordinate(0, 0));
            AddNewPiece(player, board, WHITE, ROOK, new Coordinate(0, 7));
            AddNewPiece(player, board, WHITE, KNIGHT, new Coordinate(0, 1));
            AddNewPiece(player, board, WHITE, KNIGHT, new Coordinate(0, 6));
            AddNewPiece(player, board, WHITE, BISHOP, new Coordinate(0, 2));
            AddNewPiece(player, board, WHITE, BISHOP, new Coordinate(0, 5));
            AddNewPiece(player, board, WHITE, QUEEN, new Coordinate(0, 3));
            AddNewPiece(player, board, WHITE, KING, new Coordinate(0, 4));
        }

        public static void StandardBlackSetup(Player player, IBoard board)
        {
            for (int i = 0; i <= 7; i++)
            {
                AddNewPiece(player, board, BLACK, PAWN, new Coordinate(6, i));
            }
            AddNewPiece(player, board, BLACK, ROOK, new Coordinate(7, 0));
            AddNewPiece(player, board, BLACK, ROOK, new Coordinate(7, 7));
            AddNewPiece(player, board, BLACK, KNIGHT, new Coordinate(7, 1));
            AddNewPiece(player, board, BLACK, KNIGHT, new Coordinate(7, 6));
            AddNewPiece(player, board, BLACK, BISHOP, new Coordinate(7, 2));
            AddNewPiece(player, board, BLACK, BISHOP, new Coordinate(7, 5));
            AddNewPiece(player, board, BLACK, QUEEN, new Coordinate(7, 3));
            AddNewPiece(player, board, BLACK, KING, new Coordinate(7, 4));
        }

        private static void AddNewPiece(Player player, IBoard board, Color playerColor, PieceType type, Coordinate coordinate)
        {
            IPiece piece = CreatePiece(playerColor, type, board, coordinate);
            board.AddPiece(piece, coordinate);
            player.AddPiece(piece);
            if (type == KING)
                player.King = piece;
            if (type == ROOK)
            {
                if (coordinate.file == 0)
                    player.QueensideRook = piece;
                else
                    player.KingsideRook = piece;
            }
        }
    }
}
