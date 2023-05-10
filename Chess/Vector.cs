namespace Chess;

public class Vector
{
    public Vector(int deltaRow, int deltaColumn)
    {
        if(deltaRow is < -8 or > 8)
            throw new ArgumentOutOfRangeException(nameof(deltaRow));

        if (deltaColumn is < -8 or > 8)
            throw new ArgumentOutOfRangeException(nameof(deltaColumn));
        
        DeltaRow = deltaRow;
        DeltaColumn = deltaColumn;
    }

    public int DeltaRow { get; }
    public int DeltaColumn { get; }
    
    public static Position? operator +(Position p, Vector v) 
    {
        return Position.TryCreate(p.Row + v.DeltaRow, p.Column + v.DeltaColumn);
    }

    #region Equals
    public static bool operator ==(Vector c1, Vector c2) 
    {
        return c1.Equals(c2);
    }

    public static bool operator !=(Vector c1, Vector c2) 
    {
        return !c1.Equals(c2);
    }
    
    public bool Equals(Vector other)
    {
        return DeltaRow == other.DeltaRow && DeltaColumn == other.DeltaColumn;
    }

    public override bool Equals(object? obj)
    {
        return obj is Position other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DeltaRow, DeltaColumn);
    }
    #endregion
}