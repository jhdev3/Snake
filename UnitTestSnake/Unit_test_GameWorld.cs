using Xunit;
using Snake;

// Testing Klasses and Units in the snake program. 

namespace UnitTestSnake
{
    public class Unit_test_GameWorld
    {
        GameWorld world;
        //Xunit way of using test initialize 
        public Unit_test_GameWorld()
        {
            world  = new GameWorld(Program.WorldWidth, Program.WorldHeight);
        }

        [Fact]
        public void Update_FoodMovePlayerRight_NeedsToPass()
        {
            //arrange
            Position placeFood = new Position { x= 5, y= 10 };
            Food food = new Food(placeFood);
            Player player = new Player();
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);

            //act 
            player.playerDirection = Player.Direction.Right;
            world.Update();

            //Asseert

            Assert.Contains(food, world.gameObjects);
            Assert.Contains(player, world.gameObjects);
            Assert.Equal(4, player.position.x);
            Assert.Equal(placeFood, food.position);
        }
        [Fact]
        public void Update_SnakeEatFood_PlayerOnFoodPostion()
        {

            //Arrange
            Position placeFood = new Position { x= 4, y= 3 };
            Food food = new Food(placeFood);
            Player player = new Player();
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);
            //act 
            player.playerDirection = Player.Direction.Right;
            world.Update();

            //Assert
            Assert.Equal(placeFood.x, player.position.x);
            Assert.Equal(placeFood.y, player.position.y);
        }

        [Fact]
        public void Update_SnakeEatFood_FoodNotExistInWorld()
        {
            //Arrange   
            Position placeFood = new Position { x= 4, y= 3 };
            Food food = new Food(placeFood);
            Player player = new Player();
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);
            //act 
            player.playerDirection = Player.Direction.Right;
            world.Update(); 


            //Assert
            Assert.DoesNotContain(food, world.gameObjects);

        }


       
    }

}