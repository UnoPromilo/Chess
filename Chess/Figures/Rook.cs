namespace Chess.Figures;

public class Rook : LinearFigure
{
    public Rook(Board board, Color color, Position position) : base(board, color, position)
    {
    }

    public override IEnumerable<Position> GetValidPositions()
    {
        return CheckDirectionForPossibleMoves(delta => new Vector(delta, 0))            //Up
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(-delta, 0)))     //Down
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(0, delta)))      //Right
            .Concat(CheckDirectionForPossibleMoves(delta => new Vector(0, -delta)));    //Left
    }
    
    public override Figure Clone(Board board)
    {
        return new Rook(board, Color, Position);
    }
}