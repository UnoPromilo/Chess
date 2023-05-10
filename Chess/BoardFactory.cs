using Chess.Figures;
// ReSharper disable  ObjectCreationAsStatement

namespace Chess;

public static class BoardFactory
{
    public static Board CreateNewWithDefaultValues()
    {
        Board board = new();
#pragma warning disable CA1806
        new Rook(board, Color.White, new Position(0, 0));
        new Knight(board, Color.White, new Position(0, 1));
        new Bishop(board, Color.White, new Position(0, 2));
        new Queen(board, Color.White, new Position(0, 3));
        new King(board, Color.White, new Position(0, 4));
        new Bishop(board, Color.White, new Position(0, 5));
        new Knight(board, Color.White, new Position(0, 6));
        new Rook(board, Color.White, new Position(0, 7));
        new Pawn(board, Color.White, new Position(1, 0));
        new Pawn(board, Color.White, new Position(1, 1));
        new Pawn(board, Color.White, new Position(1, 2));
        new Pawn(board, Color.White, new Position(1, 3));
        new Pawn(board, Color.White, new Position(1, 4));
        new Pawn(board, Color.White, new Position(1, 5));
        new Pawn(board, Color.White, new Position(1, 6));
        new Pawn(board, Color.White, new Position(1, 7));
        
        new Rook(board, Color.Black, new Position(7, 0));
        new Knight(board, Color.Black, new Position(7, 1));
        new Bishop(board, Color.Black, new Position(7, 2));
        new Queen(board, Color.Black, new Position(7, 3));
        new King(board, Color.Black, new Position(7, 4));
        new Bishop(board, Color.Black, new Position(7, 5));
        new Knight(board, Color.Black, new Position(7, 6));
        new Rook(board, Color.Black, new Position(7, 7));
        new Pawn(board, Color.Black, new Position(6, 0));
        new Pawn(board, Color.Black, new Position(6, 1));
        new Pawn(board, Color.Black, new Position(6, 2));
        new Pawn(board, Color.Black, new Position(6, 3));
        new Pawn(board, Color.Black, new Position(6, 4));
        new Pawn(board, Color.Black, new Position(6, 5));
        new Pawn(board, Color.Black, new Position(6, 6));
        new Pawn(board, Color.Black, new Position(6, 7));
#pragma warning restore CA1806

        return board;
    }
}