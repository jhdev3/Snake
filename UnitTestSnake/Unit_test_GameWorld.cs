using Xunit;
using Snake;

// Testing Klasses and Units in the snake program. 

namespace UnitTestSnake
{
    public class Unit_test_GameWorld
    {
        [Fact]
        public void Update_FoodMovePlayerRight_NeedsToPass()
        {
            //arrange
            GameWorld world = new GameWorld(50, 20);
            Position placeFood = new Position { x= 5, y= 10 };
            Food food = new Food(placeFood);
            Player player = new Player();
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);

            //act - Creating the Food Object
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
            GameWorld world = new GameWorld(50, 20);
            Position placeFood = new Position { x= 4, y= 3 };
            Food food = new Food(placeFood);
            Player player = new Player();
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);
            //act - Creating the Food Object
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
            GameWorld world = new GameWorld(50, 20);
            Position placeFood = new Position { x= 4, y= 3 };
            Food food = new Food(placeFood);
            Player player = new Player();
            world.gameObjects.Add(player);
            world.gameObjects.Add(food);
            //act - Creating the Food Object
            player.playerDirection = Player.Direction.Right;
            world.Update(); //Blir dem lika 
          //  world.Update();//ÄR dom lika 2nd one that is the updated Food Object :)


            //Assert
           // Fixing The Method Should make this pass :)
            Assert.DoesNotContain(food, world.gameObjects);

        }
    }
}