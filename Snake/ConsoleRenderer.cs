﻿namespace Snake
{
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // TODO Konfigurera Console-fönstret enligt världens storlek

#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowSize(gameWorld.Width, gameWorld.Height + 1);  // Fungerar Bara på Windows gissar att det är rätt xD
            Console.CursorVisible=false;
#pragma warning restore CA1416 // Validate platform compatibility

            world = gameWorld;
        }

        public void Render()
        {
            foreach( GameObject obj in world.gameObjects)
            {
                Console.SetCursorPosition(obj.position.x, obj.position.y);
                Console.Write(obj.Appearance);
            }
            Console.SetCursorPosition(0, world.Height);
            Console.Write($"Points {world.points}");
        }
        public void Render_Blank()
        {
            foreach (GameObject obj in world.gameObjects)
            {
                Console.SetCursorPosition(obj.position.x, obj.position.y);
                Console.Write(" ");
            }
        }
    }
}