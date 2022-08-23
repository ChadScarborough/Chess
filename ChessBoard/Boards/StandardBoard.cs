using ChessBoard.Pieces;
using static ChessBoard.Boards.SquareFactory;

namespace ChessBoard.Boards
{
    public class StandardBoard : IBoard
    {
        private const int SQUARES_PER_ROW = 8;
        private Square[,] _squares;

        public StandardBoard()
        {
            _squares = new Square[SQUARES_PER_ROW, SQUARES_PER_ROW];
            FillSquares();
        }

        public void AddPiece(IPiece piece, Coordinate coordinate)
        {
            Square square = GetSquareByCoordinate(coordinate);
            square.SetPiece(piece);
        }

        public Square GetSquareByCoordinate(Coordinate coordinate)
        {
            return _squares[coordinate.rank, coordinate.file];
        }

        public Square GetSquareByCoordinate(int rank, int file)
        {
            return GetSquareByCoordinate(new Coordinate(rank, file));
        }

        public void RemovePiece(Coordinate coordinate)
        {
            Square square = GetSquareByCoordinate(coordinate);
            if(square.GetPiece() != null)
                square.GetPiece().Destroy();
        }

        public void RemovePiece(int rank, int file)
        {
            Coordinate coordinate = new Coordinate(rank, file);
            RemovePiece(coordinate);
        }

        public override string ToString()
        {
            //TODO: Clean this up
            return
                $"_________________________________\n" +
                $"|   |   |   |   |   |   |   |   |\n" +
                $"|_{_squares[7, 0]}_|_{_squares[7, 1]}_|_{_squares[7, 2]}_|_{_squares[7, 3]}_|_{_squares[7, 4]}_|_{_squares[7, 5]}_|_{_squares[7, 6]}_|_{_squares[7, 7]}_|\n" +
                $"|   |   |   |   |   |   |   |   |\n" +
                $"|_{_squares[6, 0]}_|_{_squares[6, 1]}_|_{_squares[6, 2]}_|_{_squares[6, 3]}_|_{_squares[6, 4]}_|_{_squares[6, 5]}_|_{_squares[6, 6]}_|_{_squares[6, 7]}_|\n" +
                $"|   |   |   |   |   |   |   |   |\n" +
                $"|_{_squares[5, 0]}_|_{_squares[5, 1]}_|_{_squares[5, 2]}_|_{_squares[5, 3]}_|_{_squares[5, 4]}_|_{_squares[5, 5]}_|_{_squares[5, 6]}_|_{_squares[5, 7]}_|\n" +
                $"|   |   |   |   |   |   |   |   |\n" +
                $"|_{_squares[4, 0]}_|_{_squares[4, 1]}_|_{_squares[4, 2]}_|_{_squares[4, 3]}_|_{_squares[4, 4]}_|_{_squares[4, 5]}_|_{_squares[4, 6]}_|_{_squares[4, 7]}_|\n" +
                $"|   |   |   |   |   |   |   |   |\n" +
                $"|_{_squares[3, 0]}_|_{_squares[3, 1]}_|_{_squares[3, 2]}_|_{_squares[3, 3]}_|_{_squares[3, 4]}_|_{_squares[3, 5]}_|_{_squares[3, 6]}_|_{_squares[3, 7]}_|\n" +
                $"|   |   |   |   |   |   |   |   |\n" +
                $"|_{_squares[2, 0]}_|_{_squares[2, 1]}_|_{_squares[2, 2]}_|_{_squares[2, 3]}_|_{_squares[2, 4]}_|_{_squares[2, 5]}_|_{_squares[2, 6]}_|_{_squares[2, 7]}_|\n" +
                $"|   |   |   |   |   |   |   |   |\n" +
                $"|_{_squares[1, 0]}_|_{_squares[1, 1]}_|_{_squares[1, 2]}_|_{_squares[1, 3]}_|_{_squares[1, 4]}_|_{_squares[1, 5]}_|_{_squares[1, 6]}_|_{_squares[1, 7]}_|\n" +
                $"|   |   |   |   |   |   |   |   |\n" +
                $"|_{_squares[0, 0]}_|_{_squares[0, 1]}_|_{_squares[0, 2]}_|_{_squares[0, 3]}_|_{_squares[0, 4]}_|_{_squares[0, 5]}_|_{_squares[0, 6]}_|_{_squares[0, 7]}_|\n";
        }

        private void FillSquares()
        {
            for (int i = 0; i < SQUARES_PER_ROW; i++)
            {
                for (int j = 0; j < SQUARES_PER_ROW; j++)
                {
                    _squares[i, j] = CreateSquare(i, j, this);
                }
            }
        }

        public void MovePiece(IPiece piece, Square square)
        {
            square.SetPiece(piece);
            piece.HasMoved = true;
        }

        public void MovePiece(IPiece piece, Coordinate coordinate)
        {
            Square targetSquare = GetSquareByCoordinate(coordinate);
            MovePiece(piece, targetSquare);
        }
    }
}
