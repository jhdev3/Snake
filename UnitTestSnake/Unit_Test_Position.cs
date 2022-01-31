using Xunit;
using Snake;
using static Snake.Player;

// Testing Klasses and Units in the snake program. 

namespace UnitTestSnake
{ 
    public class Unit_Test_Position
    {
        [Fact]
        public void Position_X_Y_Test()
        {
            //arrange
            Position xy = new Position { x = 5, y=10 };
            //act
            xy.x = 4;
            //assert
            Assert.NotNull(xy);
            Assert.Equal(4, xy.x);
            Assert.Equal(10, xy.y);

        }
    }
}