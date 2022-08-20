namespace ChessBoard.Boards
{
    public static class SquareFactory
    {
        public static Square CreateSquare(int rank, int file, IBoard board)
        {
            Coordinate coordinate = new Coordinate(rank, file);
            return new Square(coordinate, board);
        }
    }
}
