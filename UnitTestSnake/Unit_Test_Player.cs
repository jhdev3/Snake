using Xunit;
using Snake;

// Testing Klasses and Units in the snake program. 

namespace UnitTestSnake
{
    public class UnitTest1
    {
        [Fact]
        public void Player_Move_Up()
        {
            //arrange
            Player p = new Player(new Posistion { x = 10, y = 10 });
            // act
            p.playerMove = Player.Direction.Up;
            p.Update();
            //assert
            Assert.NotNull(p);
            Assert.Equal(9, p.position.x);
            Assert.Equal('X', p.Appearance);
        }
    }
}