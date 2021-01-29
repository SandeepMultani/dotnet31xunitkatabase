using System.Collections.Generic;
using Xunit;
namespace KataBaseXunit.App.Tests
{
    public class Tests
    {
        private const int Width = 2;
        private const int Height = 2;
        private readonly List<(int, int)> _aliveCellCoords;
        public Tests()
        {
            _aliveCellCoords = new List<(int, int)>
            {
                (1,1)
            };
        }

        [Fact]
        public void GivenAGrid_WhenCellIsDeadOrAlive_ThenGridReturnsCorrectState()
        {
            //act
            var sut = new Grid(Width, Height);
            //assert
            Assert.False(sut.IsCellAliveAt(0,0));
            Assert.False(sut.IsCellAliveAt(0,1));
            Assert.False(sut.IsCellAliveAt(1,0));
            Assert.False(sut.IsCellAliveAt(1,1));
        }
        
        [Fact]
        public void GivenAGrid_WhenCellIsSetToAlive_ThenIsAlive()
        {
            //act
            var sut = new Grid(Width, Height, _aliveCellCoords);
            //assert
            Assert.False(sut.IsCellAliveAt(0,0));
            Assert.False(sut.IsCellAliveAt(0,1));
            Assert.False(sut.IsCellAliveAt(1,0));
            Assert.True(sut.IsCellAliveAt(1,1));
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void LiveCellWithNotEnoughLiveNeighboursDies(int liveNeighbours)
        {
            var sut = new AliveCell();
            var result = sut.Age(liveNeighbours);
            Assert.IsType<DeadCell>(result);
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void LiveCellWithTwoOrThreeNeighboursSurvives(int liveNeighbours)
        {
            var sut = new AliveCell();
            var result = sut.Age(liveNeighbours);
            Assert.IsType<AliveCell>(result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public void LiveCellWithMoreThanThreeLiveNeighboursDies(int noOfLiveNeighbours)
        {
            var sut = new AliveCell();
            var result = sut.Age(noOfLiveNeighbours);
            Assert.IsType<DeadCell>(result);
        }

        [Fact]
        public void DeadCellWithExactlyThreeAliveNeighboursAlive()
        {
            var sut = new DeadCell();
            var result = sut.Age(3);
            Assert.IsType<AliveCell>(result);
        }
    }
}