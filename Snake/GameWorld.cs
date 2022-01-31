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
            foreach (GameObject obj in gameObjects)
            {
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
       
