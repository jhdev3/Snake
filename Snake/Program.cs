namespace Snake;

class Program
{
    /// <summary>
    /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
    /// </summary>
    static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;
    /// <summary>
    /// To Set the GameWorlds Width and Height, used for easy UItesting
    /// </summary>
    public const int WorldWidth = 50;
    public const int WorldHeight = 20;

    /// <summary>
    /// Using one Loop and The inparmeters decides the GameMode
    /// Playing with AI = No Collision
    /// Playing Classic = Collision 
    /// </summary>
    /// <param name="AI"> Want AI or not</param>
    /// <param name="name"> Name of the player or Team</param>
    static void Loop(bool AI = false, string name = "Snake")
    {
        Console.Clear();
        // Initialisera spelet
        const int frameRate = 5;
        GameWorld world = new GameWorld(WorldWidth, WorldHeight);
        ConsoleRenderer renderer = new ConsoleRenderer(world);

        //Player 1 things they need:)
        Points p1p2points = new Points(0, name, new Position { x = 0, y = world.Height });
        renderer.AddToPointsList(p1p2points);
        Player PlayerSnake = new Player(new Position {x=3, y=3 },p1p2points , (char) 2,ConsoleColor.Green);
        world.gameObjects.Add(PlayerSnake);



        //Creates the objects needed for GameMode2 Adding them if its true. 
        //Could use 2 diffrent Game Loops for prittier code ;)
        Player PlayerSnake2 = new Player(new Position { x=world.Width-4, y=3 }, p1p2points, (char)2, ConsoleColor.Blue);
        Points AIpoints = new Points(0, "TheAmazingAIs", new Position { x = WorldWidth-20, y = world.Height });
        TheGreatAI AIsnake = new TheGreatAI(world, new Position { x = world.Width-4, y = world.Height-4 }, AIpoints);
        AISnake AIsnake2 = new AISnake(world, new Position { x = 3, y = world.Height-4 }, AIpoints);
        bool Collision = true;
        bool body = true;
        //Tip Uncomment some rows if u want less players/AIs ;)
        if (AI) { 
            renderer.AddToPointsList(AIpoints);
            world.gameObjects.Add(AIsnake);
            world.gameObjects.Add(AIsnake2);
            world.gameObjects.Add(PlayerSnake2);
            Collision = false;
            body = false; // This mode with body on the snake is a bit annoing at this point rendering 4 bodys makes the render quirky 
        }



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
            //If key = prev key then read a new key to "Clear" the inputstream buffer"
            ConsoleKey key = ReadKeyIfExists();
            while (key != ConsoleKey.NoName && key == prevKey)
            {
                key = ReadKeyIfExists();
            }
            prevKey = key;

            running = Player1Move(PlayerSnake, key);
            

            if (AI)
            {
                Player2Move(PlayerSnake2, key);
                AIsnake.SmarterAI();
                AIsnake2.AIselectDirection();
            }


            // Uppdatera världen och rendera om

            renderer.Render_Blank();//Remove old frame/positions of the objects
 
            //Create new positons/frame
            if(running)//Want to quit with q keyPress
                running = world.Update(Collision, body); //Adding some rules
            
            renderer.Render();

            //Rules playing with AI
            if (AI)
            {
                //If the players or the AI get 50 points the game ends. 
                if (AIpoints.points >= 50 || p1p2points.points >= 50)
                {
                    running = false;

                }
            }
           
            
            // Mät hur lång tid det tog
            double frameTime = Math.Ceiling(1000.0 / frameRate - (DateTime.Now - before).TotalMilliseconds);
            if (frameTime > 0)
            {
                // Vänta rätt antal millisekunder innan loopens nästa varv
                Thread.Sleep((int)frameTime);
            }
        }

        Console.Clear();
        //Need more size to write out the hugging snakes ;) 
        Console.SetWindowSize(WorldWidth+30, WorldHeight + 20);  // SetWindowSize only works on Windows

        Console.SetCursorPosition(Console.WindowWidth/2 , 1);

        //Render som output after game is over.
        if (AI) { 
            if (p1p2points.points >= 50)
            {
                Console.WriteLine("GAME OVER: You won!!!");
            }
            else
            {
                Console.WriteLine("GAME OVER You lost!!!");
            }
        }
        else {
            Console.WriteLine("GAME OVER");

            Console.SetCursorPosition(Console.WindowWidth/2, 2);
            Console.Write(PlayerSnake.points);

        }

        Console.WriteLine(AsciiArt.huggingSnakes);
        Console.WriteLine("Press Enter to Quit the game");

        Console.ReadLine();




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
        Console.Write(AsciiArt.snakeWord);
        Console.WriteLine(AsciiArt.snakeHead);
        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, 8);
        Console.WriteLine("Choose game mode: ");
        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, 10);
        Console.WriteLine(" 1 Classic Snake");
        Console.SetCursorPosition((Console.WindowWidth - 20) / 2, 12);
        Console.WriteLine(" 2 Compete vs AI collision of");
        Console.SetCursorPosition((Console.WindowWidth +14) / 2, 8);

        string choice = Console.ReadLine(); 

        switch(choice)
        {
            case "2":
                Loop(true, "Team Goat");
                break;
            default:
                Loop();
                break;
        }

        

    }
}
