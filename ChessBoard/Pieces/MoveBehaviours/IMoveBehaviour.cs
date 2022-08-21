using ChessBoard.Boards;

namespace ChessBoard.Pieces.MoveBehaviours
{
    public interface IMoveBehaviour
    {
        bool CanMove(Coordinate targetLocation);
    }
}
