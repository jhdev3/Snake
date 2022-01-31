﻿namespace Snake;

class Program
{
    /// <summary>
    /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
    /// </summary>
    static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;
    static void Loop()
    {
        // Initialisera spelet
        const int frameRate = 5;
        GameWorld world = new GameWorld(50,20);
        ConsoleRenderer renderer = new ConsoleRenderer(world);


        // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
        Player worm = new Player();
        world.gameObjects.Add(worm);

        var Random = new Random();
        Position foodPlacement = new Position { x = Random.Next(50), y= Random.Next(20)};
        Food food = new Food(foodPlacement);
        world.gameObjects.Add(food);

        // ...

        // Huvudloopen
        bool running = true;
        while (running)
        {
            // Kom ihåg vad klockan var i början
            DateTime before = DateTime.Now;

            // Hantera knapptryckningar från användaren
            ConsoleKey key = ReadKeyIfExists();
            switch (key)
            {
                case ConsoleKey.Q:
                    running = false;
                    break;
                case ConsoleKey.UpArrow:
                    worm.playerDirection = Player.Direction.Up;

                    break;
                case ConsoleKey.DownArrow:
                    worm.playerDirection = Player.Direction.Down;

                    break;
                case ConsoleKey.LeftArrow:
                    worm.playerDirection = Player.Direction.Left;

                    break;
                case ConsoleKey.RightArrow:
                    worm.playerDirection = Player.Direction.Right;

                    break;

                    // TODO Lägg till logik för andra knapptryckningar
                    // ...
            }

            // Uppdatera världen och rendera om
            renderer.Render_Blank();
            world.Update();
            renderer.Render();

            // Mät hur lång tid det tog
            double frameTime = Math.Ceiling(1000.0 / frameRate - (DateTime.Now - before).TotalMilliseconds);
            if (frameTime > 0)
            {
                // Vänta rätt antal millisekunder innan loopens nästa varv
                Thread.Sleep((int)frameTime);
            }
        }
    }

    static void Main(string[] args)
    {
        // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
        Loop();
    }
}
