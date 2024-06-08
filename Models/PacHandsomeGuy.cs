using PacMan.Abstract;
using PacMan.Service;
using Raylib_cs;

namespace PacMan.Models
{
    public class PacHandsomeGuy : ACharacter
    {
        private static readonly Random _rand = new Random();

        public PacHandsomeGuy(string name) : base(name)
        {
            Color = Color.Red;
        }


        protected override void GenerateStats()
        {
            Dice diceOneConstruct = new(30);
            LifePoint = diceOneConstruct.DiceShooter(_rand);
        }
    }
}