using System.Collections.Generic;
using Xunit;

namespace KataBaseXunit.App.Tests
{
    public class CellLiveNeighboursTests
    {
        [Fact]
        public void GivenAGrid_GridIs1By1_ThenCellIsDead()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0)};
            var sut = new Grid(1,1, aliveCells);

            sut.AdvanceGeneration();

            Assert.False(sut.IsCellAliveAt(0, 0));
        }

        [Fact]
        public void GiveAGrid_GridIs2By1_ThenAliveNeighboursForCellIsZero()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (1, 0)};
            
            var sut = new Grid(2,1, aliveCells);

            sut.AdvanceGeneration();
            
            Assert.False(sut.IsCellAliveAt(0, 0));
            Assert.False(sut.IsCellAliveAt(1,0));
        }
        
        [Fact]
        public void GiveAGrid_GridIs1By2_ThenAliveNeighboursForCellIsZero()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (0, 1)};
            
            var sut = new Grid(1,2, aliveCells);

            sut.AdvanceGeneration();

            Assert.False(sut.IsCellAliveAt(0, 0));
            Assert.False(sut.IsCellAliveAt(0,1));
        }
        
        [Fact]
        public void GiveAGrid_GridIs2By1_ThenAliveNeighboursForCellAreCorrect()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (1, 0)};
            
            var sut = new Grid(2,1, aliveCells);

            sut.AdvanceGeneration();

            Assert.False(sut.IsCellAliveAt(0, 0));
            Assert.False(sut.IsCellAliveAt(1,0));
        }
        
        [Fact]
        public void GiveAGrid_GridIs1By2_ThenAliveNeighboursForCellIs1()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (0, 1)};
            
            var sut = new Grid(1,2, aliveCells);

            sut.AdvanceGeneration();

            Assert.False(sut.IsCellAliveAt(0, 0));
            Assert.False(sut.IsCellAliveAt(0,1));
        }
        
        [Fact]
        public void GiveAGrid_GridIs2By2_ThenAliveNeighboursForCellsAre3()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (0, 1), (1,0), (1,1)};
            
            var sut = new Grid(2,2, aliveCells);

            sut.AdvanceGeneration();

            Assert.True(sut.IsCellAliveAt(0, 0));
            Assert.True(sut.IsCellAliveAt(0,1));
            Assert.True(sut.IsCellAliveAt(1,0));
            Assert.True(sut.IsCellAliveAt(1,1));
        }

        [Fact]
        public void GivenAGrid_GridIs3by2_ThenCellsAreCorrect()
        {
            var aliveCells = new List<(int x, int y)> {(0, 1), (1,0), (1,1),  (2,1)};

            var sut = new Grid(3,2, aliveCells);

            sut.AdvanceGeneration();

            Assert.True(sut.IsCellAliveAt(0, 0));
            Assert.True(sut.IsCellAliveAt(0, 1));
            Assert.True(sut.IsCellAliveAt(1, 0));
            Assert.True(sut.IsCellAliveAt(1, 1));
            Assert.True(sut.IsCellAliveAt(2, 0));
            Assert.True(sut.IsCellAliveAt(2, 1));

        }
    }
}