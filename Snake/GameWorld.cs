namespace Snake
{
    class GameWorld
    {
        public int Width = 0;
        public int Height = 0;

        public List<GameObject> gameObjects = new List<GameObject>();

        public GameWorld(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool Update(bool collision)
        {

            foreach (GameObject obj in gameObjects.ToList()) //returns list of elements för "Sequencen" 
            {
                obj.Update();

                if (obj is Player)
                {

                    //Player going to Hell ?
                   Player_Inside_the_World(obj.position);

                    foreach (GameObject fobj in gameObjects)
                    {
                        if (fobj is Food)
                        {
                            if (fobj.position.IsEqual(obj.position))
                            {
                                Player player = (Player)obj; //Pass by refrence to new PlayerBodyPart.
                                gameObjects.Add(new PlayerBodyPart(player.Positions.Count()-1, player));
                                player.points.AddPoints();

                                gameObjects.Remove(fobj);
                                Create_Food();
                                break;
                            }
                        }
                        if (fobj is PlayerBodyPart)
                        {
                            if (fobj.position.IsEqual(obj.position) && collision == true)
                            {
                                return false;//The player obj should lose the game here
                            }
                        }
                    }
                }

            }

            return true;    
        }
        
        /// <summary>
        /// The World is not flat ;)  
        /// https://en.wikipedia.org/wiki/Eratosthenes
        ///   Creates a new position if the player goes outside of the GamingWorld
        /// </summary>
        /// <param name="pos"> Snake posistion</param>
        /// <returns>new or same posistion</returns>
        private void Player_Inside_the_World(Position pos)
        {
            //Height
            if (pos.y >= Height)
            {
                pos.y = 0;
            }

            else if (pos.y < 0)
            {
                pos.y = Height - 1;
            }
            //Width
            else if (pos.x >= Width)
            {
                pos.x = 0;
            }

            else if (pos.x < 0)
            {
                pos.x = Width - 1;
            }
        }

        /// <summary>
        /// Creates Food at random posistion
        /// </summary>
        public void Create_Food()
        {
            var Random = new Random();
            Position foodPosistion = new Position { x = Random.Next(this.Width), y = Random.Next(this.Height) };
            gameObjects.Add(new Food(foodPosistion));
        }
    }
}

