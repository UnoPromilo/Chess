namespace Chess.Figures;

public class Pawn : Figure
{
    public Pawn(Board board, Color color, Position position) : base(board, color, position)
    {
    }

    protected override bool IsMoveValidInternal(Position newPosition)
    {
        Figure? figureAtNewPosition = Board.GetFigureAtOrDefault(newPosition);
        if(figureAtNewPosition is not null) 
            return FightMove(newPosition);

        return PeacefulMove(newPosition);
    }

    private bool FightMove(Position newPosition)
    {
        if(Color == Color.White && newPosition.Row != Position.Row + 1)
                return false;
        
        if (Color == Color.Black && newPosition.Row != Position.Row - 1)
            return false;

        if(newPosition.Column - Position.Column is not 1 and not -1)
            return false;

        return true;
    }

    private bool PeacefulMove(Position newPosition)
    {
        if (newPosition.Column != Position.Column)
            return false;

        if (Color == Color.White)
        {
            if(newPosition.Row - Position.Row is not 2 and not 1)
                return false;
            
            if (newPosition.Row - Position.Row == 2)
            {
                Position positionInBetween = new(Position.Row + 1, Position.Column);
                if (Board.GetFigureAtOrDefault(positionInBetween) is not null) 
                    return false;
            }
        }
        else
        {
            if(Position.Row - newPosition.Row is not 2 and not 1)
                return false;
            
            if (Position.Row - newPosition.Row  == 2)
            {
                Position positionInBetween = new(Position.Row - 1, Position.Column);
                if (Board.GetFigureAtOrDefault(positionInBetween) is not null) 
                    return false;
            }  
        }
        
        return true;
    }
    
    public override Figure Clone(Board board)
    {
        return new Pawn(board, Color, Position);
    }
}
