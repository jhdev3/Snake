using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Snake;

namespace UnitTestSnake
{
    public class AI_test
    {
        GameWorld world;
        //Xunit way of using test initialize 
        public AI_test()
        {
            world  = new GameWorld(Program.WorldWidth, Program.WorldHeight);
        }
        [Fact]
        public void AIselectDirection_BasicMovmentUp_DirectionUp()
        {
            //Arrange   
            Food food = new Food(new Position { x = 5, y= 4 });
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=5, y = 5 });
            world.gameObjects.Add(AI);

            //act - Snake moving up
            AI.AIselectDirection();

            //Assert
            Assert.Equal(Player.Direction.Up, AI.playerDirection);

        }

        [Fact]
        public void AIselectDirection_BasicMovmentLeft_DirectionLeft()
        {
            //Arrange   
            Food food = new Food(new Position { x = 4, y= 5 });
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=5, y = 5 });
            world.gameObjects.Add(AI);

            //act - Snake moving left
            AI.AIselectDirection();

            //Assert
            Assert.Equal(Player.Direction.Left, AI.playerDirection);

        }

     

    }
}
