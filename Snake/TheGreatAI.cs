using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// Computer controlled player 
    /// Competes against the player for food 
    /// 
    /// SmarterAI used to change direction
    /// 
    /// This AI is hard to win against :)
    /// 
    ///     
    /// Could be used for UI-Testing
    /// </summary>
    internal class TheGreatAI : Player
    {
        private GameWorld _AIWorld;
        //private Direction _AIDirection;
        public TheGreatAI(GameWorld world, Position start, char look = 'A')
        {
            position = start;
            Appearance = look;
            _AIWorld = world;
            this.playerDirection = Direction.Up;
        }

        /// <summary>
        /// Used to change the direction of the Aisnake 
        ///  
        /// </summary>
        public void SmarterAI()
        {
            Position food = getFoodPosistion();
            int xDistance = Calculate_XShortestPath(food.x);
            int yDistance = 0;

            if (xDistance == 0)
                yDistance = Calculate_YShortestPath(food.y);//yDistance not used but it will change the direction anyway ;)
        }
        /// <summary>
        /// Get Closet posistion of Food Object incase there are more then 1 food in the world.
        /// </summary>
        /// <returns>Food Object Posistion</returns>
        private Position getFoodPosistion()
        {
            int shortestDistance = 10000;
            int totalDistnace;
            Position YummyFood = new Position();    
            foreach (var food in _AIWorld.gameObjects)
            {
                if (food is Food)
                {

                    totalDistnace = Calculate_XShortestPath(food.position.x) +
                                    Calculate_YShortestPath(food.position.y);


                    if(totalDistnace < shortestDistance)
                    {
                        shortestDistance = totalDistnace;  
                        YummyFood = food.position;
                    }
                }
            }

            return YummyFood;
        }
        /// <summary>
        /// Calculates the shortest path to a cordinate in X axis.
        /// </summary>
        /// <param name="foodX">x Coridnate</param>
        /// <returns>Shortest distnace in x Axis</returns>
        public int Calculate_XShortestPath(int foodX)
        {
            int distance = foodX - position.x; 

            if (distance > 0)//Checks if its closer going threw left wall
            {
                int distanceGoingLeft = _AIWorld.Width- foodX + position.x;
                if (distanceGoingLeft < distance)
                {
                    this.playerDirection = Direction.Left;
                    return distanceGoingLeft;
                }
                else
                {
                    this.playerDirection = Direction.Right;
                    return distance;
                }
            }
            else if (distance == 0)
                return 0;
            else
            {   //Closer going threw right wall
                distance = distance * -1;
                int distanceGoingRight = _AIWorld.Width - position.x + foodX;
                if (distanceGoingRight < distance)
                {
                    this.playerDirection=Direction.Right;
                    return distanceGoingRight;
                }

                this.playerDirection=Direction.Left;
                return distance;

            }

        }

        /// <summary>
        /// Calculate the shortestDistance in Y axis setting the direction and returns the value
        /// </summary>
        /// <param name="foodY"> Y Cordinate </param>
        /// <returns>Shortest distance in Y</returns>
        public int Calculate_YShortestPath(int foodY)
        {
            int distance = foodY - position.y;
            int distanceTop = _AIWorld.Height - foodY + position.y;

            int distanceBottom = _AIWorld.Height - position.y + foodY;

            if (distance > 0 &&   distanceTop < distance)//Shorter going around from top
            {
                playerDirection = Direction.Up;
                return distanceTop;
            }
            else if (distanceBottom < (distance *-1))//Shorter Going from bottom wall
            {
                playerDirection = Direction.Down;
                return distanceBottom;
            }
            else
            {
                if (distance < 0)// if negativ go up else go down
                {

                    this.playerDirection = Direction.Up;
                    return distance *-1;
                }

                this.playerDirection = Direction.Down;
                return distance;
            }
        }


    }

    
}