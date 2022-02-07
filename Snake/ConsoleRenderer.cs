namespace Snake
{
    class ConsoleRenderer
    {
        private GameWorld world;
        private List<Points> playerPoints;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // TODO Konfigurera Console-fönstret enligt världens storlek

#pragma warning disable CA1416 // Validate platform compatibility
           Console.SetWindowSize(gameWorld.Width, gameWorld.Height + 1);  // Fungerar Bara på Windows gissar att det är rätt xD
#pragma warning restore CA1416 // Validate platform compatibility
            Console.CursorVisible = false;
            playerPoints = new List<Points>();

            world = gameWorld;
        }

        public void Render()
        {

            // TODO Rendera spelvärlden (och poängräkningen)
            

            // Använd

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
                Console.SetCursorPosition(obj.position.x, obj.position.y);
                Console.Write(" ");
            }
        }

        public void AddToPointsList(Points p)   
        {
            playerPoints.Add(p);
        }
    }
}