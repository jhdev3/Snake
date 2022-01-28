using Xunit;
using Snake;

// Testing Klasses and Units in the snake program. 

namespace UnitTestSnake
{
    public class UnitTest1
    {
        [Fact]
        public void Player_Move_Up_x_9()
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
        [Fact]
        public void Player_Move_Down_x_11()
        {
            //arrange
            Player p = new Player(new Posistion { x = 10, y = 10 });
            // act
            p.playerMove = Player.Direction.Down;
            p.Update();
            //assert
            Assert.Equal(11 , p.position.x);
        }
        [Fact]
        public void Player_Move_Right_y_11()
        {
            //arrange
            Player p = new Player(new Posistion { x = 10, y = 10 });
            // act
            p.playerMove = Player.Direction.Right;
            p.Update();
            //assert
            Assert.Equal(11, p.position.y);
        }
        [Fact]
        public void Player_Move_Right_y_9()
        {
            //arrange
            Player p = new Player(new Posistion { x = 10, y = 10 });
            // act
            p.playerMove = Player.Direction.Left;
            p.Update();
            //assert
            Assert.Equal(9, p.position.y);
        }
    }
}