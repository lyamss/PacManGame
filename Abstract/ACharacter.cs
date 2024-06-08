using PacMan.Service;
using Raylib_cs;
namespace PacMan.Abstract
{
    public abstract class ACharacter
    {
        private int _characterWidth = 30;
        public int CharacterWidth
        {
            get { return _characterWidth; }
            protected set { _characterWidth = value; }
        }


        private int _characterHeight = 30;
        public int CharacterHeight
        {
            get { return _characterHeight; }
            protected set { _characterHeight = value; }
        }


        private double _characterSpeed = 0.9f;
        public double CharacterSpeed
        {
            get { return _characterSpeed; }
            protected set { _characterSpeed = value; }
        }


        private int _characterX = 0;
        public int CharacterX
        {
            get { return _characterX; }
            set { _characterX = value; }
        }


        private int _characterY = 200;
        public int CharacterY
        {
            get { return _characterY; }
            set { _characterY = value; }
        }


        private Color _color = Color.Blue;
        public Color Color
        {
            get { return _color; }
            protected set { _color = value; }
        }



        protected string Name { get; set; }
        protected int LifePoint { get; set; }
        private static readonly Random _rand = new();


        protected ACharacter(string Name) => this.Name = Name;


        protected virtual void GenerateStats()
        {
            Dice diceOneConstruct = new(50);
            LifePoint = diceOneConstruct.DiceShooter(_rand);
        }
    }
}