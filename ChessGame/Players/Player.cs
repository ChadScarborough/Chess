using ChessBoard.Pieces;
using ChessBoard.Boards;
using static ChessBoard.Globals.Enums;

namespace ChessGame.Players
{
    public abstract class Player
    {
        protected IBoard _board;
        public abstract List<IPiece> Pieces { get; init; }
        public IPiece King { get; set; }
        public IPiece KingsideRook { get; set; }
        public IPiece QueensideRook { get; set; }
        public int TotalValue
        {
            get
            {
                int total = 0;
                foreach (IPiece piece in Pieces)
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

        public void MakeMoveFromStringInput(string input)
        {
            MoveStringInterpreter interpreter = new MoveStringInterpreter(this, input);
            interpreter.InterpretMoveString();
        }

        
        public void CastleKingside()
        {
            if (King.HasMoved) return;
            if (KingsideRook.HasMoved) return;
            int rank = King.Location.GetRank();
            if (_board.GetSquareByCoordinate(rank, 5).IsOccupied() ||
                _board.GetSquareByCoordinate(rank, 6).IsOccupied())
                return;
            _board.MovePiece(King, new Coordinate(rank, 6));
            _board.MovePiece(KingsideRook, new Coordinate(rank, 5));    
        }

        public void CastleQueenside()
        {
            if (King.HasMoved) return;
            if (QueensideRook.HasMoved) return;
            int rank = King.Location.GetRank();
            if (_board.GetSquareByCoordinate(rank, 3).IsOccupied() ||
                _board.GetSquareByCoordinate(rank, 2).IsOccupied() ||
                _board.GetSquareByCoordinate(rank, 1).IsOccupied())
                return;
            _board.MovePiece(King, new Coordinate(rank, 1));
            _board.MovePiece(QueensideRook, new Coordinate(rank, 2));
        }
        
    }
}
