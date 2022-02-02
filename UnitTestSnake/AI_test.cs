﻿using System;
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
        //Checking X-axis
        [Fact]
        public void AIselectDirection_BasicMovmentUp_DirectionUp()
        {
            //Arrange   
            Food food = new Food(new Position { x = 5, y= 4 });
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=5, y = 5 });
            world.gameObjects.Add(AI);

            //act - Snake moving up
            AI.Update();

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
            AI.Update();

            //Assert
            Assert.Equal(Player.Direction.Left, AI.playerDirection);

        }

        [Fact]
        public void AIUpdate_EdgeMovmentYaxis_DirectionUp()
        {
            //Arrange   
            Food food = new Food(new Position { x = 5, y= world.Height-1});
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=5, y = 0 });
            world.gameObjects.Add(AI);

            //act - Snake moving up
            AI.Update();

            //Assert
            Assert.Equal(Player.Direction.Up, AI.playerDirection);

        }
        [Fact]

        public void AIUpdate_EdgeMovmentXaxis_DirectionLeft()
        {
            //Arrange   
            Food food = new Food(new Position { x = world.Width-1, y= 5 });
            world.gameObjects.Add(food);

            AISnake AI = new AISnake(world, new Position { x=0, y = 6 });
            world.gameObjects.Add(AI);

            //act - Snake moving up
            AI.Update();

            //Assert
            Assert.Equal(Player.Direction.Left, AI.playerDirection);

        }


    }
}
