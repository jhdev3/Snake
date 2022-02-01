using Xunit;
using Snake;

// Testing Klasses and Units in the snake program. 

namespace UnitTestSnake
{
    public class UnitTest1
    {
        [Fact]
        public void Player_MoveUp_y_9()
        {
            //arrange
            Player p = new Player(new Position { x = 10, y = 10 });
            // act
            p.playerDirection = Player.Direction.Up;
            p.Update();
            //assert
            Assert.NotNull(p);
            Assert.Equal(9, p.position.y);
            //Assert.Equal('X', p.Appearance);
        }
        [Fact]
        public void Player_MoveDown_y_11()
        {
            //arrange
            Player p = new Player(new Position { x = 10, y = 10 });
            // act
            p.playerDirection = Player.Direction.Down;
            p.Update();
            //assert
            Assert.Equal(11 , p.position.y);
        }
        [Fact]
        public void Player_MoveRight_x11()
        {
            //arrange
            Player p = new Player(new Position { x = 10, y = 10 });
            // act
            p.playerDirection = Player.Direction.Right;
            p.Update();
            //assert
            Assert.Equal(11, p.position.x);
        }
        [Fact]
        public void Player_MoveLeft_x9()
        {
            //arrange
            Player p = new Player(new Position { x = 10, y = 10 });
            // act
            p.playerDirection = Player.Direction.Left;
            p.Update();
            //assert
            Assert.Equal(9, p.position.x);
        }
    }
}