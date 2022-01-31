namespace Snake
{
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // TODO Konfigurera Console-fönstret enligt världens storlek

#pragma warning disable CA1416 // Validate platform compatibility
           Console.SetWindowSize(gameWorld.Width, gameWorld.Height + 1);  // Fungerar Bara på Windows gissar att det är rätt xD
#pragma warning restore CA1416 // Validate platform compatibility

            world = gameWorld;
        }

        public void Render()
        {
            Console.Clear();

            // TODO Rendera spelvärlden (och poängräkningen)
            Console.SetCursorPosition(0, world.Height);
            Console.Write($"Points {world.points}");

            // Använd

            Player_Out_Of_Field();
            foreach( GameObject obj in world.gameObjects)
            {
                Console.SetCursorPosition(obj.position.x, obj.position.y);
                Console.Write(obj.Appearance);
            }
        }
        private void Player_Out_Of_Field()
        {

            //Height
            if (world.gameObjects[0].position.y > world.Height-1)
            {
                world.gameObjects[0].position.y = 0;
            }

            else if (world.gameObjects[0].position.y < 0)
            {
                world.gameObjects[0].position.y = world.Height-1;
            }
            //Width
            else if (world.gameObjects[0].position.x > world.Width-1)
            {
                world.gameObjects[0].position.x = 0;
            }

            else if (world.gameObjects[0].position.x < 0)
            {
                world.gameObjects[0].position.x = world.Width-1;
            }

            //  Console.WriteLine(gameObjects[0].position.x);
        }
    }
}