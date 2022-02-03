namespace Snake;

class Program
{
    /// <summary>
    /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
    /// </summary>
    static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

    public const int WorldWidth = 50;
    public const int WorldHeight = 20;
    //public static readonly int WorldHeight = 20;



    static void Loop()
    {
        // Initialisera spelet
        const int frameRate = 5;
        GameWorld world = new GameWorld(WorldWidth, WorldHeight);
        ConsoleRenderer renderer = new ConsoleRenderer(world);


        // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
        Player worm = new Player();
        world.gameObjects.Add(worm);

        Player worm2 = new Player();
        world.gameObjects.Add(worm2);
        worm2.Appearance = '#';
        worm2.position = new Position { x = 10, y = 10 };

        var Random = new Random();
        Position foodPlacement = new Position { x = Random.Next(50), y= Random.Next(20)};
        Food food = new Food(foodPlacement);
        world.gameObjects.Add(food);

        world.gameObjects.Add(new Food(new Position { x = 5, y = 6}));




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
                    case ConsoleKey.P:
                        worm.playerDirection = Player.Direction.NotMoving;
                        worm2.playerDirection = Player.Direction.NotMoving;

                        break;
                    case ConsoleKey.W:
                        worm2.playerDirection = Player.Direction.Up;

                        break;
                    case ConsoleKey.S:
                        worm2.playerDirection = Player.Direction.Down;

                        break;
                    case ConsoleKey.A:
                        worm2.playerDirection = Player.Direction.Left;

                        break;
                    case ConsoleKey.D:
                        worm2.playerDirection = Player.Direction.Right;
                        break;

                        // TODO Lägg till logik för andra knapptryckningar
                        // ...
                }
                       
                       
             
        
            // Uppdatera världen och rendera om

            renderer.Render_Blank();//Remove old frame/positions

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
    //Creating some Gravity for the little worm :) 
   

    static void Main(string[] args)
    {
        // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
        Loop();
    }
}
