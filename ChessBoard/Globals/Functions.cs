namespace ChessBoard.Globals
{
    public static class Functions
    {
        public static void GuardAgainstOffBoardMoves(int rank, int file)
        {
            if (rank < 0 || rank >= 8 || file < 0 || file >= 8) 
                throw new Exception("Piece cannot move off the board");
        }
    }
}
