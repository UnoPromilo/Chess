using System.Collections.Immutable;

namespace Chess.Figures;

public class Knight : Figure
{
    private static readonly ImmutableList<Vector> PossibleMoves = new List<Vector>
    {
        new (1, 2),
        new (2, 1),
        new (2, -1),
        new (1, -2),
        new (-1, -2),
        new (-2, -1),
        new (-2, 1),
        new (-1, 2)
    }.ToImmutableList();

    public Knight(Board board, Color color, Position position) : base(board, color, position)
    {
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
        return new Knight(board, Color, Position);
    }
}