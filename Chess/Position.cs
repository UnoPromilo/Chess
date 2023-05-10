namespace Chess;

public readonly struct Position : IEquatable<Position>
{
    public Position(int row, int column)
    {
        if(row is < 0 or > 7)
            throw new ArgumentOutOfRangeException(nameof(row));

        if (column is < 0 or > 7)
            throw new ArgumentOutOfRangeException(nameof(column));
        
        Row = row;
        Column = column;
    }
    
    public static Position? TryCreate(int row, int column)
    {
        if(row is < 0 or > 7)
            return null;

        if (column is < 0 or > 7)
            return null;
        
        return new Position(row, column);
    }

    public int Row { get; }
    public int Column { get; }


    #region Equals
    public static bool operator ==(Position c1, Position c2) 
    {
        return c1.Equals(c2);
    }

    public static bool operator !=(Position c1, Position c2) 
    {
        return !c1.Equals(c2);
    }
    
    public bool Equals(Position other)
    {
        return Row == other.Row && Column == other.Column;
    }

    public override bool Equals(object? obj)
    {
        return obj is Position other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }
    #endregion
}