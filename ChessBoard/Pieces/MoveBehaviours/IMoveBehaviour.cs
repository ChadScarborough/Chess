using ChessBoard.Boards;

namespace ChessBoard.Pieces.MoveBehaviours
{
    public interface IMoveBehaviour
    {
        void Move(Coordinate startingLocation, Coordinate endingLocation);
    }
}
