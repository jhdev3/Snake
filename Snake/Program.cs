namespace Snake;

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



        Player worm = new Player();
        world.gameObjects.Add(worm);

        world.Create_Food();
        world.Create_Food();
        world.Create_Food();

        Player worm2 = new Player();
        world.gameObjects.Add(worm2);
        worm2.Appearance = '☺';
        worm2.position = new Position { x = 10, y = 10 };
        worm2.color = ConsoleColor.Green;


        TheGreatAI AIsnake = new TheGreatAI(world, new Position { x = WorldWidth-4, y = WorldHeight-4});
        world.gameObjects.Add(AIsnake);

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

            running = Player1Move(worm, key);

           Player2Move(worm2, key);


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
