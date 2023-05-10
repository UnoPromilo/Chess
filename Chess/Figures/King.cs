using System.Collections.Immutable;

namespace Chess.Figures;

public class King : Figure
{
    private static readonly ImmutableList<Vector> PossibleMoves = new List<Vector>
    {
        new (1,0),
        new (1,1),
        new (0,1),
        new (-1,1),
        new (-1,0),
        new (-1,-1),
        new (0,-1),
        new (1,-1)
    }.ToImmutableList();
    
    public King(Board board, Color color, Position position) : base(board, color, position)
    {
    }
    
    public override bool IsMoveValid(Position newPosition)
    {
        if(HasMoved)
            return base.IsMoveValid(newPosition);
        
        if (newPosition.Column == Position.Column + 2) // Kingside castling
        {
            if (Board.GetFigureAtOrDefault(new Position(Position.Row, Position.Column + 1)) is not null)
                return false;
            
            if (Board.GetFigureAtOrDefault(new Position(Position.Row, Position.Column + 2)) is not null)
                return false;
            
            if (Board.GetFigureAtOrDefault(new Position(Position.Row, Position.Column + 3)) is not Rook rook)
                return false;
            
            if (rook.HasMoved)
                return false;

            return true;
        }
        
        if (newPosition.Column == Position.Column - 2) // Kingside castling
        {
            if (Board.GetFigureAtOrDefault(new Position(Position.Row, Position.Column - 1)) is not null)
                return false;
            
            if (Board.GetFigureAtOrDefault(new Position(Position.Row, Position.Column - 2)) is not null)
                return false;
            
            if (Board.GetFigureAtOrDefault(new Position(Position.Row, Position.Column - 3)) is not null)
                return false;
            
            if (Board.GetFigureAtOrDefault(new Position(Position.Row, Position.Column - 4)) is not Rook rook)
                return false;
            
            if (rook.HasMoved)
                return false;

            return true;
        }
        
        return base.IsMoveValid(newPosition);
    }

    protected override bool IsMoveValidInternal(Position newPosition)
    {
        return PossibleMoves
            .Select(move => Position + move)
            .Any(positionToCheck => positionToCheck == newPosition);
    }

    public override IEnumerable<Position> GetValidPositions()
    {
        return PossibleMoves
            .Select(move => Position + move)
            .Where(move => move is not null && IsMoveValid(move.Value))
            .Select(move => move!.Value);
    }
    
    public override Figure Clone(Board board)
    {
        return new King(board, Color, Position);
    }
}