namespace Snake
{
    internal abstract class GameObject
    {
        // TODO
        public Position position = new Position();
        public char Appearance;

        public abstract void Update();
    }
}