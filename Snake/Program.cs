﻿namespace Snake;

class Program
{
    /// <summary>
    /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
    /// </summary>
    static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;
    /// <summary>
    /// To Set the GameWorlds Width and Height
    /// </summary>
    public const int WorldWidth = 50;
    public const int WorldHeight = 20;


    static void Loop()
    {
        Console.CursorVisible = false;
        // Initialisera spelet
        const int frameRate = 5;
        GameWorld world = new GameWorld(WorldWidth, WorldHeight);
        ConsoleRenderer renderer = new ConsoleRenderer(world);

        Points p1p2points = new Points(0, "TeamGoat", new Position { x = 0, y = world.Height });

        Player PlayerSnake = new Player(new Position {x=3, y=3 },p1p2points , '☺', ConsoleColor.Green);
        world.gameObjects.Add(PlayerSnake);

       Player PlayerSnake2 = new Player(new Position { x=world.Width-4, y=3 }, p1p2points, '☺', ConsoleColor.Blue);
        world.gameObjects.Add(PlayerSnake2);


        renderer.AddToPointsList(p1p2points);   
        Points AIpoints = new Points(0, "TheAmazingAI", new Position { x = WorldWidth-20, y = world.Height });
        renderer.AddToPointsList(AIpoints);

        TheGreatAI AIsnake = new TheGreatAI(world, new Position { x = world.Width-4, y = world.Height-4 }, AIpoints);
        world.gameObjects.Add(AIsnake); 

        world.Create_Food();
        world.Create_Food();
        world.Create_Food();

        


        ConsoleKey prevKey = ConsoleKey.NoName;

        // Huvudloopen
        bool running = true;
        while (running)
        {
            // Kom ihåg vad klockan var i början
            DateTime before = DateTime.Now;

           
            // Making the Game more responsive. 
            //Notice more when u play with 2 players.
            ConsoleKey key = ReadKeyIfExists();
            while (key != ConsoleKey.NoName && key == prevKey)
            {
                key = ReadKeyIfExists();
            }
            prevKey = key;

            running = Player1Move(PlayerSnake, key);

           Player2Move(PlayerSnake2, key);


            // Uppdatera världen och rendera om

            renderer.Render_Blank();//Remove old frame/positions

            AIsnake.SmarterAI();
            //Create new positons/frames
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
    /// <summary>
    /// Setting Direction of Player one Using the arrow keys
    /// </summary>
    /// <param name="p1">Player 1 sets the Direction</param>
    /// <param name="key"> Choose Direction</param>
    /// <returns>False to end the game</returns>
    static bool Player1Move(Player p1, ConsoleKey key)
    { 

        bool running = true;
        switch (key)
        {
            case ConsoleKey.Q:
                running = false;
                break;
            case ConsoleKey.UpArrow:
                p1.playerDirection = Player.Direction.Up;

                break;
            case ConsoleKey.DownArrow:
                p1.playerDirection = Player.Direction.Down;

                break;
            case ConsoleKey.LeftArrow:
                p1.playerDirection = Player.Direction.Left;

                break;
            case ConsoleKey.RightArrow:
                p1.playerDirection = Player.Direction.Right;
                break;      
        }
        return running;

    }
    /// <summary>
    /// Setting Direction of player two using A,S, D, W
    /// </summary>
    /// <param name="p2">Sets player2 Direction</param>
    /// <param name="key">Input key from input stream</param>
    static void Player2Move(Player p2, ConsoleKey key)
    {

        switch (key)
        {
            
            case ConsoleKey.W:
                p2.playerDirection = Player.Direction.Up;

                break;
            case ConsoleKey.S:
                p2.playerDirection = Player.Direction.Down;

                break;
            case ConsoleKey.A:
                p2.playerDirection = Player.Direction.Left;

                break;
            case ConsoleKey.D:
                p2.playerDirection = Player.Direction.Right;
                break;
        }

    }


    static void Main(string[] args)
    {

        // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
        Loop();
    }
}
