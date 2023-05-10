using Chess.Figures;

namespace Chess;

public class GameController
{
    private readonly Board _board;

    public Color Player { get; private set; } = Color.White;
    public Color NextPlayer => Player == Color.White ? Color.Black : Color.White;

    public GameController(Board board)
    {
        _board = board;
    }

    public bool TryMakeMove(Move move)
    {
        //Validation
        Figure? figure = _board.GetFigureAtOrDefault(move.From);
        if (figure is null) return false;
        if (figure.Color != Player) return false;
        if (figure.IsMoveValid(move.To) == false) return false;
        if (IsCheckAfterMove(move)) return false;
        
        //Move
        if (WillItBeACastling(figure, move))
            DoCastling(move);
        
        _board.MoveFigure(move);
        Player = NextPlayer;
        
        return true;
    }
    
    public bool IsMat()
    {
        if (IsCheck() == false) return false;
        
        return _board.Figures
            .Where(figure => figure.Color == Player)
            .SelectMany(figure => figure.GetValidMoves())
            .Any(move => IsCheckAfterMove(move) == false) == false;
    }
    
    public bool IsStaleMate()
    {
        if (IsCheck()) return false;
        
        return _board.Figures
            .Where(figure => figure.Color == Player)
            .SelectMany(figure => figure.GetValidMoves())
            .Any(move => IsCheckAfterMove(move) == false) == false;
    }
    
    public Figure? GetFigureAtOrDefault(Position position)
    {
        return _board.GetFigureAtOrDefault(position);
    }
    
    public bool IsCheck()
    {
        return IsCheck(_board, Player);
    }

    private bool IsCheckAfterMove(Move move)
    {
        Board clonedBoard = _board.Clone();
        clonedBoard.MoveFigure(move);
        return IsCheck(clonedBoard, Player);
    }
    
    private void DoCastling(Move move)
    {
        int direction = move.To.Column - move.From.Column;
        int rookColumn = direction > 0 ? 7 : 0;
        int rookNewColumn = direction > 0 ? 5 : 3;
        Position rookPosition = new(move.From.Row, rookColumn);
        Position rookNewPosition = new(move.From.Row, rookNewColumn);
        _board.MoveFigure(new Move(rookPosition, rookNewPosition));
    }

    private static bool IsCheck(Board board, Color player)
    {
        King king = board.GetKing(player);
        return board.Figures
            .Where(figure => figure.Color != player)
            .SelectMany(figure => figure.GetValidPositions())
            .Any(position => position == king.Position);
    }

    private static bool WillItBeACastling(Figure figure, Move move)
    {
        if (figure is not King) return false;
        return Math.Abs(move.From.Column - move.To.Column) == 2;
    }
}