namespace Chess;

public readonly struct Move
{
    public Move(Position from, Position to)
    {
        From = from;
        To = to;
    }

    public Position To { get; }

    public Position From { get;}
}