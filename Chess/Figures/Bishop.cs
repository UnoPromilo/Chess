namespace Chess.Figures;

public class Bishop : LinearFigure
{
    public Bishop(Board board, Color color, Position position) : base(board, color, position)
    {
    }

    public override IEnumerable<Position> GetValidPositions()
    {
        return CheckDirectionForPossibleMoves(delta => new Vector(delta, delta))            //Up Right
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(delta, -delta)))     //Up Left
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(-delta, delta)))     //Down Right
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(-delta, -delta)));   //Down Left
    }

    public override Figure Clone(Board board)
    {
        return new Bishop(board, Color, Position);
    }
}