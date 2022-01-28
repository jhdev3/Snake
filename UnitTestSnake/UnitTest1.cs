using Xunit;
using Snake;

// Testing Klasses and Units in the snake program. 

namespace UnitTestSnake
{
    public class UnitTest1
    {
        [Fact]
        public void Position_X_Y_Test()
        {
            //arrange
            Posistion xy = new Posistion { x = 5, y=10 };
            //act
            xy.x = 4;
            //assert
            Assert.NotNull(xy);
            Assert.Equal(4, xy.x);
            Assert.Equal(10, xy.y);

        }
    }
}