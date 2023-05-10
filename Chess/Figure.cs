using System.Collections.Immutable;

namespace Chess;

public abstract class Figure
{
    protected readonly Board Board;

    protected Figure(Board board, Color color, Position position)
    {
        Board = board;
        Color = color;
        Board.AddFigure(this, position);
    }

    public Position Position => GetPosition();
    public Color Color { get; }
    public bool HasMoved { get; private set; }

    public virtual bool IsMoveValid(Position newPosition)
    {
        if (newPosition == Position) return false;
        
        Figure? figureAtNewPosition = Board.GetFigureAtOrDefault(newPosition);
        if(figureAtNewPosition is not null && figureAtNewPosition.Color == Color)
            return false;
        
        return IsMoveValidInternal(newPosition);
    }
    
    public virtual IEnumerable<Position> GetValidPositions()
    {
        // ReSharper disable once LoopCanBeConvertedToQuery
        foreach (int row in Enumerable.Range(0,8))
        {
            foreach (var column in Enumerable.Range(0,8))
            {
                Position position = new(row, column);
                if (IsMoveValid(position))
                {
                    yield return position;
                }
                
            }
        }
    }
    
    public IEnumerable<Move> GetValidMoves()
    {
        return GetValidPositions().Select(position => new Move(Position, position));
    }

    public void RecordMove()
    {
        HasMoved = true;
    }

    public abstract Figure Clone(Board board);

    protected abstract bool IsMoveValidInternal(Position newPosition);
    
    private Position GetPosition()
    {
        Position? position = Board.CheckFigurePosition(this);
        if(position is null)
            throw new Exception("Figure is not on the board");

        return position.Value;
    }
}