using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Snake;
namespace UnitTestSnake
{
    public class GameWorld_Edge_Tests
    {
        GameWorld world;
        //Xunit way of using test initialize 
        public GameWorld_Edge_Tests()
        {
            world  = new GameWorld(Program.WorldWidth, Program.WorldHeight);
        }
        //Checking X-axis
        [Fact]
        public void Update_SnakeEatFoodRightEdgeComingFromLeftEdge_FoodNotExistInWorld()
        {
            //Arrange   
            Position placeFood = new Position { x= world.Width-1, y= 3 };
            Food food = new Food(placeFood);
            Player player = new Player(new Position{ x=0, y = 3});
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);

            //act - Snake moving from pos.x 0 to the other edge of the 2D world and eating the food thats there :)
            player.playerDirection = Player.Direction.Left;
            world.Update(); 

            //Assert
            Assert.DoesNotContain(food, world.gameObjects);

        }
        [Fact]
        public void Update_SnakeEatFoodLeftEdgeComingFromRightEdge_FoodNotExistInWorld()
        {
            //Arrange   
            Position placeFood = new Position { x= 0, y= 3 };
            Food food = new Food(placeFood);
            Player player = new Player(new Position { x=Program.WorldWidth-1, y = 3 });
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);

            //Act - Snake moving from Edge of the world to start of the world and eating som food
            player.playerDirection = Player.Direction.Right;
            world.Update();

            //Assert
            Assert.DoesNotContain(food, world.gameObjects);

        }
       
        
        //Checking Y-axis
        [Fact]
        public void Update_SnakeEatFoodBottomEdgeComingFromTopEdge_FoodNotExistInWorld()
        {
            //Arrange   
            Position placeFood = new Position { x= 5, y= Program.WorldHeight-1 };
            Food food = new Food(placeFood);
            Player player = new Player(new Position { x=5, y = 0 });
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);

            //act - Snake Moving from start of the world to Edge of the world, in y-axis and eating some food:)
            player.playerDirection = Player.Direction.Up;
            world.Update();

            //Assert
            Assert.DoesNotContain(food, world.gameObjects);
        }
        [Fact]
        public void Update_SnakeEatFoodTopEdgeComingFromBottomEdge_FoodNotExistInWorld()
        {
            //Arrange   
            Position placeFood = new Position { x= 5, y= 0 };
            Food food = new Food(placeFood);
            Player player = new Player(new Position { x=5, y = Program.WorldHeight-1 });
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);

            //Act - Snake Moving from Edge of the world to start of the world and eating som food:) 
            player.playerDirection = Player.Direction.Down;
            world.Update();

            //Assert
            Assert.DoesNotContain(food, world.gameObjects);
        }

    }
}
