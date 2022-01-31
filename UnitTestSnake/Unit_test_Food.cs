using Xunit;
using Snake;

// Testing Klasses and Units in the snake program. 

namespace UnitTestSnake
{
    public class Unit_test_Food
    {
        Position placeFood = new Position { x= 5, y= 10 };    
        [Fact]
        public void Position_X_Y_Test()
        {
            //arrange
            Position f = placeFood;
            //act - Creating the Food Object
            
            //assert
            Assert.NotNull(f);
           // Assert.Equal("F", f.Appearance);
            Assert.Equal(5, f.x);
            Assert.Equal(10, f.y);

        }
    }
}