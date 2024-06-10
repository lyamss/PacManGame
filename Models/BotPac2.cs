using PacMan.Abstract;
using PacMan.Service;
using Raylib_cs;

namespace PacMan.Models
{
    public class BotPac2 : APac
    {
        private static readonly Random _rand = new Random();

        public BotPac2(string name) : base(name)
        {
            Texture = Raylib.LoadTexture("assets/sprites/pac/deathAnim/death1.png");
            PositionY = 400;
            PositionX = 400;
        }

        protected override void GenerateStats()
        {
            Dice diceOneConstruct = new(30);
            LifePoint = diceOneConstruct.DiceShooter(_rand);
        }
    }
}