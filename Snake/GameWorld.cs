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
            Console.WriteLine();

            //Player_Out_Of_Field();
            // TODO
            foreach (GameObject obj in gameObjects)
            {
                if(obj is Player)
                {

                    foreach (GameObject fobj in gameObjects)
                    {
                        if(fobj is Food)
                        {

                            if (fobj.position.IsEqual(obj.position))
                            {
                                Console.Write(fobj.position);
                                Console.Write(obj.position);


                                points++;
                                var Random = new Random();
                                Position foodPlacement = new Position { x = Random.Next(50), y= Random.Next(20) };
                                fobj.position = foodPlacement; 

                            }
                        }
                    }
                }
                obj.Update();
            }
        }

        //private void Player_Out_Of_Field()
        //{

        //    //Height
        //    if (gameObjects[0].position.y == Height)
        //    {
        //        gameObjects[0].position.y = 0;
        //    }

        //    else if (gameObjects[0].position.y == -1)
        //    {
        //        gameObjects[0].position.y = Height-1;
        //        Console.WriteLine(gameObjects[0].position.y);


        //    }
        //    //Width
        //    else if (gameObjects[0].position.x == Width)
        //    {
        //        gameObjects[0].position.x = 0;
        //    }

        //    else if (gameObjects[0].position.x == -1)
        //    {
        //        gameObjects[0].position.x = Width-1;
        //    }

        //  //  Console.WriteLine(gameObjects[0].position.x);
        //}

    }
}
       
