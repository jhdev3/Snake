namespace Snake
{
    class GameWorld
    {
        public int Width = 0;
        public int Height = 0;

        public List<GameObject> gameObjects = new List<GameObject>();

        public int points = 0;
        
        public GameWorld (int width, int height)
        {
            Width = width; 
            Height = height;   
        }

        public void Update()
        {

            // TODO
            foreach (GameObject obj in gameObjects.ToList())
            {
                obj.Update();//Player should move first :)

                if (obj is Player)
                {
                    //Player going to Hell ?
                    obj.position = Player_Inside_the_World(obj.position);

                    foreach (GameObject fobj in gameObjects)
                    {
                        if(fobj is Food)
                        {

                            if (fobj.position.IsEqual(obj.position))
                            {
                                points++;
                                gameObjects.Remove(fobj);
                                var Random = new Random();
                                Position foodPlacement = new Position { x = Random.Next(50), y = Random.Next(20) };
                                gameObjects.Add(new Food(foodPlacement));
                                break;
                            }
                        }
                    }
                }
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
       
