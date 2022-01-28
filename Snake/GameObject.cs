namespace Snake
{
    internal abstract class GameObject
    {
        // TODO
        public Posistion position = new Posistion();
        public char Appearance;

        public abstract void Update();
    }
}