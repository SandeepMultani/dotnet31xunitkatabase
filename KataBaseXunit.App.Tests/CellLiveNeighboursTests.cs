using System.Collections.Generic;
using Xunit;

namespace KataBaseXunit.App.Tests
{
    public class CellLiveNeighboursTests
    {
        [Fact]
        public void GivenAGrid_GridIs1By1_ThenAliveNeighboursForACellIsZero()
        {
            var sut = new Grid(1,1);

            var results = sut.GetNumberOfAliveNeighbours(0, 0);
            
            Assert.Equal(0, results);
        }

        [Fact]
        public void GiveAGrid_GridIs2By1_ThenAliveNeighboursForCellIsZero()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (1, 0)};
            
            var sut = new Grid(2,1, aliveCells);

            var results = sut.GetNumberOfAliveNeighbours(0, 0);
            
            Assert.Equal(1, results);
        }
        
        [Fact]
        public void GiveAGrid_GridIs1By2_ThenAliveNeighboursForCellIsZero()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (0, 1)};
            
            var sut = new Grid(1,2, aliveCells);

            var results = sut.GetNumberOfAliveNeighbours(0, 0);
            
            Assert.Equal(1, results);
        }
        
        [Fact]
        public void GiveAGrid_GridIs2By1_ThenAliveNeighboursForCellAreCorrect()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (1, 0)};
            
            var sut = new Grid(2,1, aliveCells);

            var results = sut.GetNumberOfAliveNeighbours(1, 0);
            
            Assert.Equal(1, results);
        }
        
        [Fact]
        public void GiveAGrid_GridIs1By2_ThenAliveNeighboursForCellIs1()
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (0, 1)};
            
            var sut = new Grid(1,2, aliveCells);

            var results = sut.GetNumberOfAliveNeighbours(0, 1);
            
            Assert.Equal(1, results);
        }
        
        [Theory]
        [InlineData(0,0)]
        [InlineData(0,1)]
        [InlineData(1,0)]
        [InlineData(1,1)]
        public void GiveAGrid_GridIs2By2_ThenAliveNeighboursForCellsAre3(int x, int y)
        {
            var aliveCells = new List<(int x, int y)> {(0, 0), (0, 1), (1,0), (1,1)};
            
            var sut = new Grid(2,2, aliveCells);

            var results = sut.GetNumberOfAliveNeighbours(x, y);
            
            Assert.Equal(3, results);
        }
    }
}