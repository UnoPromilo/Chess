namespace Chess.Figures;

public class Queen : LinearFigure
{
    public Queen(Board board, Color color, Position position) : base(board, color, position)
    {
    }

    public override IEnumerable<Position> GetValidPositions()
    {
        return CheckDirectionForPossibleMoves(delta => new Vector(delta, 0))                //Up
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(delta, delta)))      //Up Right
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(0, delta)))          //Right
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(-delta, delta)))     //Down Right
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(-delta, 0)))         //Down
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(-delta, -delta)))    //Down Left
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(0, -delta)))         //Left
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(delta, -delta)));    //Up Left
    }
    
    public override Figure Clone(Board board)
    {
        return new Queen(board, Color, Position);
    }
}