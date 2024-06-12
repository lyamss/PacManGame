using PacMan.Abstract;
using PacMan.Service;
using Raylib_cs;

namespace PacMan.Models
{
    public class GhostsClyde : AGhost
    {
        private static readonly Random _rand = new Random();

        public GhostsClyde(string name) : base(name)
        {
            Texture = Raylib.LoadTexture("assets/sprites/clyde.png");
        }


        protected override void GenerateStats()
        {
            Dice diceOneConstruct = new(30);
            LifePoint = diceOneConstruct.DiceShooter(_rand);
        }
    }
}