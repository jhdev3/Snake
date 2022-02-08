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
    ///     AIselectDirection used for change the direction snake dont know the world is round
    ///  
    /// Focusing on first Food object in the list in case you create more :)
    /// Could be used for UI-Testing
    /// </summary>
    internal class AISnake : Player
    {
        private GameWorld _AIWorld;
        //private Direction _AIDirection;
        public AISnake(GameWorld world, Position start, Points AI, char look = (char)165, ConsoleColor c = ConsoleColor.DarkYellow) : base(start, AI, look, c)
        {
            _AIWorld = world;
        }
        public AISnake(GameWorld world, Position start) : base(start)
        {
            _AIWorld = world;

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
