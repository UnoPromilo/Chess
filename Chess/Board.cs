using Chess.Figures;

namespace Chess;

public class Board
{
    private readonly Dictionary<Position, Figure> _board = new();
    
    public List<Figure> Figures => _board.Values.ToList();

    public Figure? GetFigureAtOrDefault(Position position)
    {
        return _board.GetValueOrDefault(position);
    }
    
    public Position? CheckFigurePosition(Figure figure)
    {
        return _board.FirstOrDefault(k=>k.Value == figure).Key;
    }
    
    public void MoveFigure(Move move)
    {
        if (move.From == move.To)
            throw new ArgumentException("From and to positions are the same");
        
        if (GetFigureAtOrDefault(move.From) is null)
            throw new ArgumentException("There is no figure at the given position");

        _board[move.To] = _board[move.From];
        _board.Remove(move.From);
    }
    
    public void AddFigure(Figure figure, Position position)
    {
        if (GetFigureAtOrDefault(position) is not null)
            throw new ArgumentException("There is already a figure at the given position");
        
        _board[position] = figure;
    }

    public King GetKing(Color color)
    {
        return _board.Where(k => k.Value.Color == color)
            .Select(k => k.Value)
            .OfType<King>()
            .Single();
    }

    public Board Clone()
    {
        Board board = new();
        foreach (var (_, figure) in _board)
        {
            figure.Clone(board);
        }

        return board;
    }
}