using Chess.Figures;

namespace Chess.Console;

public class ConsoleGameController
{
    private readonly GameController _game;

    public ConsoleGameController(GameController game)
    {
        _game = game;
    }


    public void Play()
    {
        bool isFinished = false;
        bool wasInvalidMove = false;
        while (isFinished == false)
        {
            PrintBoard();
            PrintStatus(wasInvalidMove, out isFinished);
            Move? move = GetNextMove();
            if (move is null)
            {
                wasInvalidMove = true;
                continue;
            }

            wasInvalidMove = _game.TryMakeMove(move.Value) == false;
        }

        
    }
    
    private Move? GetNextMove()
    {
        string? line = System.Console.ReadLine();
        if (line is null) return null;
        if (line[0] is < 'A' or > 'H') return null;
        if (line[1] is < '1' or > '8') return null;
        if (line[3] is < 'A' or > 'H') return null;
        if (line[4] is < '1' or > '8') return null;
        
        return new Move(new Position(line[1] - '1', line[0] - 'A'), new Position(line[4] - '1', line[3] - 'A'));
    }
    
    private void PrintBoard()
    {
        System.Console.WriteLine("  ABCDEFGH");
        foreach (int invertedRow in Enumerable.Range(0, 8))
        {
            int row = 7 - invertedRow;
            System.Console.Write($"{row + 1} ");
            foreach (int column in Enumerable.Range(0, 8))
            {
                Position position = new(row, column);
                Figure? figure = _game.GetFigureAtOrDefault(position);
                if (figure is null)
                {
                    System.Console.Write(((row + column) % 2) switch
                    {
                        0 => "☐",
                        1 => "☒",
                        _ => throw new ArgumentOutOfRangeException(nameof(position))
                    });
                    continue;
                }

                System.Console.Write(figure switch
                {
                    Pawn => figure.Color == Color.White ? "♙" : "♟",
                    Rook => figure.Color == Color.White ? "♖" : "♜",
                    Knight => figure.Color == Color.White ? "♘" : "♞",
                    Bishop => figure.Color == Color.White ? "♗" : "♝",
                    Queen => figure.Color == Color.White ? "♕" : "♛",
                    King => figure.Color == Color.White ? "♔" : "♚",
                    _ => throw new ArgumentOutOfRangeException(nameof(figure))
                });
            }
            System.Console.WriteLine($" {row + 1}");
        }
        System.Console.WriteLine("  ABCDEFGH");
    }


    private void PrintStatus(bool invalidMove, out bool isFinished)
    {
        System.Console.WriteLine();
        isFinished = true;
        if(_game.IsMat()) {System.Console.WriteLine($"Mat, {_game.NextPlayer} won!");}
        else if(_game.IsStaleMate()) System.Console.WriteLine($"Stale mate!");
        else
        {
            isFinished = false;
            if(_game.IsCheck()) System.Console.WriteLine($"Check!");
            if(invalidMove) System.Console.WriteLine($"Invalid move!");
            else System.Console.WriteLine($"Next player: {_game.Player}");
        }
    }
}