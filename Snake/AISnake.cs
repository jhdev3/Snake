﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Amazing AI Snake ;) 
namespace Snake
{
    /// <summary>
    /// Computer controlled player 
    /// </summary>
    internal class AISnake : Player
    {
        private GameWorld _AIWorld;
        //private Direction _AIDirection;
        public AISnake(GameWorld world, Position start, char look = 'A')
        {
             position = start;
             Appearance = look;
            _AIWorld = world;
            this.playerDirection = Direction.Up;
        }
        
        /// <summary>
        /// AI Choose a posistion based of Food posistion. Goal should be choose closest Direction
        /// </summary>
        public void AIselectDirection()
        {
            Position food = getFoodPosistion();
            int xDistance = food.x - position.x;
            int yDistance = food.y - position.y;

            if( xDistance == 0)
            { 
                if(yDistance > 0)
                    this.playerDirection = Direction.Down;
                else if(yDistance < 0)
                {
                    this.playerDirection = Direction.Up;
                }
            }
            else if(xDistance > 0)
            {
                this.playerDirection =  Direction.Right;
            }
            else if(xDistance < 0)
            {
                this.playerDirection = Direction.Left;
            }            
        }
        /// <summary>
        /// Get posistion of Food Object
        /// </summary>
        /// <returns>Food Object Posistion</returns>
        private Position getFoodPosistion()
        {            
            foreach (var food in _AIWorld.gameObjects)
            {
                if (food is Food)
                {
                    return food.position;
                }
            }
            return new Position { x= 0, y = 0};
        }
    }
}
