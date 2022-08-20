namespace ChessBoard.Globals
{
    public static class Enums
    {
        public enum Color { White, Black }

        public const Color WHITE = Color.White;
        public const Color BLACK = Color.Black;

        public enum PieceType { Pawn, Knight, Bishop, Rook, Queen, King }

        public const PieceType PAWN = PieceType.Pawn;
        public const PieceType KNIGHT = PieceType.Knight;
        public const PieceType BISHOP = PieceType.Bishop;
        public const PieceType ROOK = PieceType.Rook;
        public const PieceType QUEEN = PieceType.Queen;
        public const PieceType KING = PieceType.King;
    }
}
