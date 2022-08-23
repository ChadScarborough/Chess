using ChessBoard.Pieces;
using static ChessBoard.Globals.Enums;

namespace ChessGame.Players
{
    public class MoveStringInterpreter
    {
        private Player _player;
        private string _input;

        private Dictionary<char, int> files = new Dictionary<char, int>
        {
            {'a', 0 }, {'b', 1 }, {'c', 2 }, {'d', 3 }, {'e', 4 }, {'f', 5 }, {'g', 6 }, {'h', 7 }
        };

        private Dictionary<char, PieceType> pieceAbbreviations = new Dictionary<char, PieceType>
        {
            { 'N', KNIGHT }, { 'B', BISHOP },  { 'R', ROOK }, { 'Q', QUEEN }, { 'K', KING }
        };

        public MoveStringInterpreter(Player player, string input)
        {
            _player = player;
            _input = input;
        }

        public void InterpretMoveString()
        {
            // TODO: Include castling
            switch (_input.Length)
            {
                case 2:
                    InterpretPawnMove();
                    return;
                case 3:
                    InterpretPieceMove();
                    return;
                case 4:
                    if(_input[1] == 'x')
                    {
                        InterpretCaptureMove();
                    }
                    return;
            }
        }

        private void InterpretCaptureMove()
        {
            if (files.ContainsKey(_input[0]))
            {
                InterpretPawnCapture();
                return;
            }
            if (pieceAbbreviations.ContainsKey(_input[0]))
            {
                InterpretPieceCapture();
                return;
            }
            throw new Exception("Invalid input");
        }

        private void InterpretPawnCapture()
        {
            int currentFile = files[_input[0]];
            GuardRankAndFile();
            int targetFile, rank;
            GetRankAndFile(out targetFile, out rank);
            foreach(IPiece pawn in _player.Pieces)
            {
                if (pawn.Type != PAWN)
                    continue;
                if (pawn.Location.GetFile() == currentFile &&
                    pawn.CanMove(rank, targetFile))
                {
                    pawn.Move(rank, targetFile);
                    return;
                }
            }
        }

        private void InterpretPieceCapture()
        {
            InterpretPieceMove();
        }

        private void InterpretPieceMove()
        {
            GuardPieceAbbreviation();
            GuardRankAndFile();
            int file, rank;
            GetRankAndFile(out file, out rank);
            PieceType type = pieceAbbreviations[_input[0]];
            foreach (IPiece piece in _player.Pieces)
            {
                if (piece.Type != type)
                    continue;
                if (piece.CanMove(rank, file))
                {
                    piece.Move(rank, file);
                    return;
                }
            }
        }

        private void GuardPieceAbbreviation()
        {
            if (pieceAbbreviations.Keys.Contains(_input[0]) == false)
                throw new Exception("Invalid piece abbreviation");
        }

        private void InterpretPawnMove()
        {
            GuardRankAndFile();
            int file, rank;
            GetRankAndFile(out file, out rank);
            FindValidPawnMove(file, rank);
        }

        private void FindValidPawnMove(int file, int rank)
        {
            foreach (IPiece pawn in _player.Pieces)
            {
                if (pawn.Type != PAWN) continue;
                CheckForValidPawnMove(file, rank, pawn);
            }
        }

        private void GetRankAndFile(out int file, out int rank)
        {
            file = files[_input[^2]];
            rank = int.Parse(_input[^1].ToString()) - 1;
        }

        private static void CheckForValidPawnMove(int file, int rank, IPiece pawn)
        {
            if (pawn.Location.GetFile() == file && 
                pawn.CanMove(rank, file))
            {
                 pawn.Move(rank, file);
            }
        }

        private void GuardRankAndFile()
        {
            if (files.Keys.Contains(_input[^2]) == false)
            {
                throw new Exception("Invalid file input");
            }
            if (int.TryParse(_input[^1].ToString(), out int result) == false)
            {
                throw new Exception("Invalid rank input");
            }
        }
    }
}
