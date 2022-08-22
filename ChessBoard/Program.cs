using ChessBoard.Boards;
using ChessBoard.Pieces;
using static ChessBoard.Globals.Enums;
using static ChessBoard.Pieces.PieceFactory;

StandardBoard board = new StandardBoard();
IPiece rook = CreatePiece(BLACK, ROOK, board, new Coordinate(4, 4));
Console.WriteLine(board);
rook.Move(4, 1);
Console.WriteLine(board);
rook.Move(0, 1);
Console.WriteLine(board);
rook.Move(5, 5);
Console.WriteLine(board);