namespace Snake
{
    class ConsoleRenderer
    {
        private GameWorld world;
        private List<Points> playerPoints;
        public ConsoleRenderer(GameWorld gameWorld)
        {

#pragma warning disable CA1416 // Validate platform compatibility
            //Height + 1 to add room for the points Field. 
           Console.SetWindowSize(gameWorld.Width, gameWorld.Height + 1);  // SetWindowSize only works on Windows
#pragma warning restore CA1416 // Validate platform compatibility
           
            Console.CursorVisible = false;
            playerPoints = new List<Points>();

            world = gameWorld;
        }
        public void Render()
        {

            foreach( GameObject obj in world.gameObjects)
            {
              
             
                Console.SetCursorPosition(obj.position.x, obj.position.y);
                Console.ForegroundColor = obj.color;                
                Console.Write(obj.Appearance);
                
            }

            Console.ResetColor();
            foreach ( var p in playerPoints)
            {
                Console.SetCursorPosition(p.pos.x, p.pos.y);

                Console.Write(p);

            }
        }
        public void Render_Blank()
        {
            foreach (GameObject obj in world.gameObjects)
            {

                if (obj is PlayerBodyPart)
                {

                    PlayerBodyPart part = (PlayerBodyPart)obj;
                    //Dont need to remove Every BodyPart :)
                    if (part.PosInPlayerList+1 ==  part.Player.bodyParts)//
                    {
                        Console.SetCursorPosition(obj.position.x, obj.position.y);
                        Console.Write(" ");
                    }

                }
                else
                {
                    Console.SetCursorPosition(obj.position.x, obj.position.y);
                    Console.Write(" ");
                }
            }
        }

        public void AddToPointsList(Points p)   
        {
            playerPoints.Add(p);
        }
    }
}