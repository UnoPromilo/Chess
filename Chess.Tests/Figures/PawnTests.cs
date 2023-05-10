using Chess.Figures;

namespace Chess.Tests.Figures;

public class PawnTests
{
    [Test]
    public void When_WhiteSolo_Then_PossibleMovesAreCorrect()
    {
        Board board = new();
        Pawn sut = new(board, Color.White, new Position(3, 3));
        
        List<Position> expected = new()
        {
            new Position(4, 3),
            new Position(5, 3)
        };
        
        Assert.That(sut.GetValidPositions(), Is.EquivalentTo(expected));
    }
    
    [Test]
    public void When_BlackSolo_Then_PossibleMovesAreCorrect()
    {
        Board board = new();
        Pawn sut = new(board, Color.Black, new Position(3, 3));
        
        List<Position> expected = new()
        {
            new Position(2, 3),
            new Position(1, 3)
        };
        
        Assert.That(sut.GetValidPositions(), Is.EquivalentTo(expected));
    }
    
    [Test]
    public void When_WhiteAndOpponentInFrontOf_Then_PossibleMovesAreCorrect()
    {
        Board board = new();
        _= new Pawn(board, Color.Black, new Position(4, 3));
        Pawn sut = new(board, Color.White, new Position(3, 3));
        
        Assert.That(sut.GetValidPositions(), Is.EquivalentTo(Array.Empty<Position>()));
    }
    
    [Test]
    public void When_BlackAndOpponentInFrontOf_Then_PossibleMovesAreCorrect()
    {
        Board board = new();
        _= new Pawn(board, Color.White, new Position(4, 3));
        Pawn sut = new(board, Color.Black, new Position(5, 3));
        
        Assert.That(sut.GetValidPositions(), Is.EquivalentTo(Array.Empty<Position>()));
    }
}