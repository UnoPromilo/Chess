namespace Chess.Figures;

public abstract class LinearFigure : Figure
{
    protected LinearFigure(Board board, Color color, Position position) : base(board, color, position)
    {
    }
    
    protected override bool IsMoveValidInternal(Position newPosition)
    {
        return GetValidPositions().Contains(newPosition);
    }
    
    protected IEnumerable<Position> CheckDirectionForPossibleMoves(Func<int, Vector> getVector)
    {
        foreach (var delta in Enumerable.Range(1, 7))
        {
            Vector vector = getVector(delta);
            Position? expectedPosition = Position + vector;
            if(expectedPosition is null) break;
            Figure? figureAtExpectedPosition = Board.GetFigureAtOrDefault(expectedPosition.Value);
            if(figureAtExpectedPosition is not null && figureAtExpectedPosition.Color == Color)
                break;

            if (figureAtExpectedPosition is not null && figureAtExpectedPosition.Color != Color)
            {
                yield return expectedPosition.Value;
                break;
            }
            
            yield return expectedPosition.Value;
        }
    }
}