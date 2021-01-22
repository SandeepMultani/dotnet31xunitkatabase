using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public void GivenGridDimensions_When_ThenGridIsInit()
        {
            //act
            var sut = new Grid(Width, Height);

            //assert
            Assert.Equal(Width, sut.Width);
            Assert.Equal(Height, sut.Height);
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

        // [InlineData(1,1)]
        // [Theory]
        // public void GivenAGrid_WhenCellHasHasFewerThanTwoNeighbours_ThenItDies(int x, int y)
        // {
        //     //arrange
        //     var sut = new Grid(Width, Height, new List<(int x, int y)>{(x,y)});
        //
        //     //act
        //     sut.AdvanceGeneration();
        //
        //     //assert
        //     Assert.False(sut.IsCellAliveAt(x,y));
        // }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void LiveCellWithNotEnoughLiveNeighboursDies(int liveNeighbours)
        {
            var sut = new AliveCell();
            var neighbours = Enumerable.Range(0, liveNeighbours)
                .Select(i => new AliveCell());

            var result = sut.Age(neighbours);

            Assert.IsType<DeadCell>(result);
        }
    }
}