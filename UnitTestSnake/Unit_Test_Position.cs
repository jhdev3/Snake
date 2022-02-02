using Xunit;
using Snake;
using static Snake.Player;

// Testing Klasses and Units in the snake program. 

namespace UnitTestSnake
{ 
    public class Unit_Test_Position
    {
        [Fact]
        public void Position_XandY_4and10()
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
        [Fact]
        public void Position_IsEqual_True()
        {
            //arrange
            Position xy = new Position { x = 5, y=10 };
            bool checkTrue;
            bool checkFalse;
            //act
            checkTrue = xy.IsEqual(new Position { x = 5, y = 10 });
            checkFalse = xy.IsEqual(new Position { x = 5, y = 11 });
            //assert
           Assert.True(checkTrue);
           Assert.False(checkFalse);

        }
    }
}