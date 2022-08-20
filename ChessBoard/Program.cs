ChessBoard.Boards.StandardBoard board = new ChessBoard.Boards.StandardBoard();
ChessBoard.Pieces.BlackPawn blackPawn = new ChessBoard.Pieces.BlackPawn(board, new ChessBoard.Boards.Coordinate(6, 3));
ChessBoard.Pieces.WhitePawn whitePawn = new ChessBoard.Pieces.WhitePawn(board, new ChessBoard.Boards.Coordinate(1, 2));
whitePawn.Move(3, 2);
blackPawn.Move(4, 3);
whitePawn.Move(4, 3);
Console.WriteLine(board);