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

            //Player_Out_Of_Field();
            // TODO
            foreach (GameObject obj in gameObjects.ToList())
            {
                obj.Update();//Player should move first :)

                if (obj is Player)
                {
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
       
    }
}
       
