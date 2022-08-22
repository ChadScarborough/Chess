using ChessBoard.Boards;
using ChessBoard.Pieces;
using static ChessBoard.Globals.Enums;
using static ChessBoard.Pieces.PieceFactory;

StandardBoard board = new StandardBoard();
IPiece bishop = CreatePiece(WHITE, BISHOP, board, new Coordinate(0, 0));
IPiece rook = CreatePiece(WHITE, ROOK, board, new Coordinate(7, 7));
Console.WriteLine(board);
bishop.Move(7, 7);
bishop.Move(0, 0);
Console.WriteLine(board);
