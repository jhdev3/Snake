namespace Snake
{
    internal abstract class GameObject
    {
        // TODO
        public Position position = new Position();
        public char Appearance;
        public ConsoleColor color = ConsoleColor.White;
        

        public abstract void Update();
    }
}