using PacMan.Service;
using Raylib_cs;
namespace PacMan.Abstract
{
    public abstract class AGhosts
    {
        private double _speed = 0.9f;
        public double Speed
        {
            get { return _speed; }
            protected set { _speed = value; }
        }


        private int _positionX = 12;
        public int PositionX
        {
            get { return _positionX; }
            set { _positionX = value; }
        }


        private int _positionY = 230;
        public int PositionY
        {
            get { return _positionY; }
            set { _positionY = value; }
        }


        private static Texture2D _texture;
        public static Texture2D Texture
        {
            get { return _texture; }
            protected set { _texture = value; }
        }


        public static bool Dead = false;
        public static bool Won = false;
        protected string Name;
        protected int LifePoint;
        private static readonly Random _rand = new();


        protected AGhosts(string Name) => this.Name = Name;


        protected virtual void GenerateStats()
        {
            Dice diceOneConstruct = new(50);
            LifePoint = diceOneConstruct.DiceShooter(_rand);
        }
    }
}