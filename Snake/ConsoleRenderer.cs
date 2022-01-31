namespace Snake
{
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // TODO Konfigurera Console-fönstret enligt världens storlek

#pragma warning disable CA1416 // Validate platform compatibility
           Console.SetWindowSize(gameWorld.Width, gameWorld.Height);  // Fungerar Bara på Windows gissar att det är rätt xD
           // Console.BufferHeight = gameWorld.Height;
           // Console.BufferWidth = gameWorld.Width;
#pragma warning restore CA1416 // Validate platform compatibility

            world = gameWorld;
        }

        public void Render()
        {
            // TODO Rendera spelvärlden (och poängräkningen)

            // Använd
            // Console.Clear();

           Player_Out_Of_Field();

            Console.SetCursorPosition(world.gameObjects[0].position.x, world.gameObjects[0].position.y);
            Console.Write(world.gameObjects[0].Appearance);
           



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
                Console.WriteLine(world.gameObjects[0].position.y);


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