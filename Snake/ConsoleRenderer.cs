﻿namespace Snake
{
    class ConsoleRenderer
    {
        private GameWorld world;
        public ConsoleRenderer(GameWorld gameWorld)
        {
            // TODO Konfigurera Console-fönstret enligt världens storlek

            world = gameWorld;
        }

        public void Render()
        {
            //

            // Använd Console.SetCursorPosition(int x, int y) and Console.Write(char)
        }
    }
}