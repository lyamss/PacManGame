using PacMan.Abstract;
using PacMan.Service;
using Raylib_cs;

namespace PacMan.Models
{
    public class BotPac : AGhosts
    {
        private static readonly Random _rand = new Random();

        public BotPac(string name) : base(name)
        {
            Texture = Raylib.LoadTexture("assets/sprites/pac/pacNarrow2.png");
            PositionY = 400;
            PositionX = 300;
        }


        protected override void GenerateStats()
        {
            Dice diceOneConstruct = new(30);
            LifePoint = diceOneConstruct.DiceShooter(_rand);
        }
    }
}