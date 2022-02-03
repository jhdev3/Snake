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
    /// Got 2 methods: 
    ///     AIselectDirection snake dont know the world is round
    ///     SmarterAI know that the world is round ;)
    /// Focusing on first Food object in the list 
    /// Could be used for UI-Testing
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
        /// AI Dont know the world is round easy mode :)
        /// </summary>
        public void AIselectDirection()
        {
            Position food = getFoodPosistion();
            int xDistance = food.x - position.x;
            int yDistance = food.y - position.y;

            if ( xDistance == 0)
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
        /// Super Smart AI 
        /// Cant move 
        /// </summary>
        public void SmarterAI()
        {
            Position food = getFoodPosistion();
            int xDistance = Calculate_XShortestPath(food.x);
            int yDistance = 0;

            if (xDistance == 0)
                yDistance = Calculate_YShortestPath(food.y);
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
        /// <summary>
        /// Should Calculate the shortest path in X and return correct direction
        /// </summary>
        /// <returns>Distance in xAxis</returns>
        public int Calculate_XShortestPath(int foodX)
        {
            int distance = foodX - position.x;

            if (distance > 0)//Ska gå Höger kolla om det är värt att gå vänster
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
            {
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
        /// <param name="foodY"> Position för Y </param>
        /// <returns>Shortest distance in Y</returns>

        public int Calculate_YShortestPath(int foodY)
        {
            int distance = foodY - position.y;
            int distanceTop = _AIWorld.Height - foodY + position.y;

            int distanceBottom = _AIWorld.Height - position.y + foodY;

            if (distance > 0 &&   distanceTop < distance ) 
            {
                playerDirection = Direction.Up;
                return distanceTop;
            }
            else if ( distanceBottom < (distance *-1))
            {
                playerDirection = Direction.Down;
                return distanceBottom;
            }
            else
            {
                if (distance < 0)
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
