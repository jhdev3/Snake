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

        [Fact]
        public void SmarterAI_EdgeMovmentYaxis_DirectionUp()
        {
            //Arrange   
            Food food = new Food(new Position { x = 5, y= world.Height-1});
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=5, y = 0 });
            world.gameObjects.Add(AI);

            //act - Snake moving up
            AI.SmarterAI();

            //Assert
            Assert.Equal(Player.Direction.Up, AI.playerDirection);

        }
        [Fact]
        public void SmarterAI_AiStartFoodEnd_DirectionLeft()
        {
            //Arrange   
            Food food = new Food(new Position { x = world.Width-1, y= world.Height-1 });
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=3, y = 3 });
            world.gameObjects.Add(AI);

            //act - 
            int x = AI.Calculate_XShortestPath(food.position.x);
            int y = AI.Calculate_YShortestPath(food.position.y);
            
            AI.SmarterAI();

            //Assert
            Assert.Equal(x, y);
            Assert.Equal(Player.Direction.Left, AI.playerDirection);

        }

        [Fact]
        public void CalculateXShortestPath_DirectionLeft()
        {
            //Arrange   
            Food food = new Food(new Position { x = world.Width-1, y= 5 });
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=0, y = 6 });
            world.gameObjects.Add(AI);

            //act - Snake should move Left
            int distance = AI.Calculate_XShortestPath(food.position.x);

            //Assert
            Assert.Equal(Player.Direction.Left, AI.playerDirection);
            Assert.Equal(1, distance);

        }
        [Fact]
        public void CalculateXShortestPath_DirectionRight()
        {
            //Arrange   
            Food food = new Food(new Position { x = 0, y= 5 });
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=world.Width-15, y = 5 });
            world.gameObjects.Add(AI);

            //act - Snake should move Right
            int resultat = AI.Calculate_XShortestPath(food.position.x);

            //Assert
            Assert.Equal(Player.Direction.Right, AI.playerDirection);
            Assert.Equal(15, resultat);

        }

        [Fact]
        public void CalculateYShortestPath_DirectionUP()
        {
            //Arrange   
            Food food = new Food(new Position { x = 5, y= world.Height-1 });
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=5, y = 0 });
            world.gameObjects.Add(AI);

            //act - Snake moving up
           int distance = AI.Calculate_YShortestPath(food.position.y);


            //Assert
            Assert.Equal(1, distance);
            Assert.Equal(Player.Direction.Up, AI.playerDirection);

        }
        [Fact]
        public void CalculateYShortestPath_DirectionDown()
        {
            //Arrange   
            Food food = new Food(new Position { x = 5, y= 0 });
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=5, y = world.Height-1 });
            world.gameObjects.Add(AI);

            //act - Snake moving up
            int distance = AI.Calculate_YShortestPath(food.position.y);


            //Assert
            Assert.Equal(1, distance);
            Assert.Equal(Player.Direction.Down, AI.playerDirection);

        }

    }
}
