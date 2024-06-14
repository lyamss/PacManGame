using Raylib_cs;
namespace PacMan.Abstract
{
    public abstract class ABody
    {
        private double _speed = 1.9f;
        public double Speed
        {
            get { return _speed; }
            private set { _speed = value; }
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


        private Texture2D _texture;
        public Texture2D Texture
        {
            get { return _texture; }
            private set { _texture = value; }
        }


        public bool Dead = false;
        public bool Won = false;
        protected string Name;

        protected ABody(string Name, double Speed, int PositionX, int PositionY, Texture2D Texture)
        {
            this.Name = Name;
            this.Speed = Speed;
            this.PositionX = PositionX;
            this.PositionY = PositionY;
            this.Texture = Texture;
        }
    }
}