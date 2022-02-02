namespace Snake
{
    class GameWorld
    {
        public int Width = 0;
        public int Height = 0;

        public List<GameObject> gameObjects = new List<GameObject>();
        public LinkedList<Position> playerPositions = new LinkedList<Position>();

        public int points = 0;
        
        public GameWorld (int width, int height)
        {
            Width = width; 
            Height = height;   
        }

        public void Update()
        {

            // TODO
            PlayerBody newBody = null;
            bool gameOver = false;
            foreach (GameObject obj in gameObjects.ToList())
            {
                obj.Update();//Player should move first :)

                if (obj is Player)
                {
                    playerPositions.AddFirst(obj.position.Clone());
                    for (int i = playerPositions.Count - 1; i > points; i--)
                    {
                        playerPositions.RemoveLast();
                    } 
                    //Player going to Hell ?
                    obj.position = Player_Inside_the_World(obj.position);

                    foreach (GameObject fobj in gameObjects)
                    {
                        if(fobj is Food)
                        {

                            if (fobj.position.IsEqual(obj.position))
                            {


                                newBody = new PlayerBody(points);
                                points++;
                                gameObjects.Remove(fobj);
                                var Random = new Random();
                                Position foodPlacement = new Position { x = Random.Next(50), y = Random.Next(20) };
                                gameObjects.Add(new Food(foodPlacement));
                                break;
                            }
                        }
                        if(fobj is PlayerBody)
                        {
                            if (fobj.position.IsEqual(obj.position))
                            {

                                gameOver = true;

                            }
                        }
                    }
                }
                if(obj is PlayerBody)
                {
                    PlayerBody objectBody = (PlayerBody)obj;
                    obj.position = playerPositions.ElementAt(objectBody.Step);
                }
                obj.Update();
            }
            if (gameOver)
            {
                Console.WriteLine("Game over!");
                Console.WriteLine("Press enter to try again");
                Console.ReadLine();
                Console.Clear();
                gameOver = false;
                points = 0;
                Player player = (Player)gameObjects.Find(x => x is Player);
                player.position = new Position { x = 3, y = 3 };
                player.playerDirection = Player.Direction.NotMoving;
                var Random = new Random();
                Position foodPlacement = new Position { x = Random.Next(50), y = Random.Next(20) };
                Food food = (Food)gameObjects.Find(x => x is Food);
                food.position = foodPlacement;
                List<GameObject> newGameObjects = new List<GameObject>();
                foreach (GameObject obj in gameObjects) {
                    if(!(obj is PlayerBody))
                    {
                        newGameObjects.Add(obj);
                    }
                }
                gameObjects = newGameObjects;
                
            }
            if (newBody != null)
            {
                gameObjects.Add(newBody);
            }
        }
        //Adding som Gravity to the player :)
        private Position Player_Inside_the_World(Position pos)
        {
            //Height
            if (pos.y >= Height)
            {
                pos.y = 0;
            }

            else if (pos.y < 0)
            {
                pos.y = Height-1;
            }
            //Width
            else if (pos.x >= Width)
            {
                pos.x = 0;
            }

            else if (pos.x < 0)
            {
                pos.x = Width-1;
            }

            return pos;

        }

    }
}
       
