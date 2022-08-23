using ChessBoard.Pieces;
using ChessBoard.Boards;
using static ChessBoard.Globals.Enums;

namespace ChessGame.Players
{
    public abstract class Player
    {
        protected IBoard _board;
        public abstract List<IPiece> Pieces { get; init; }
        public int TotalValue { get
            {
                int total = 0;
                foreach(IPiece piece in Pieces)
                {
                    if (piece.Type == KING) continue;
                    total += piece.Value;
                }
                return total;
            } 
        }
        
        public Player(IBoard board)
        {
            _board = board;
        }

        public void MovePiece(IPiece piece, Coordinate targetLocation)
        {
            piece.Move(targetLocation.rank, targetLocation.file);
        }

        public void MovePiece(IPiece piece, int rank, int file)
        {
            piece.Move(rank, file);
        }

        public void AddPiece(IPiece piece)
        {
            Pieces.Add(piece);
        }

        public void RemovePiece(IPiece piece)
        {
            Pieces.Remove(piece);
        }

        public abstract void Setup();
    }
}
