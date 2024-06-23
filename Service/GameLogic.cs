using PacMan.Abstract;
using Raylib_cs;
using PacMan.Models;
namespace PacMan.Service
{
    public class GameLogic : AGameLogicBase
    {
        public override void UpdateGhostsPosition(Ghosts ghost)
        {
            int newX = ghost.PositionX;
            int newY = ghost.PositionY;

            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                newX += (int)Math.Round(ghost.Speed);
            }
            if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                newX -= (int)Math.Round(ghost.Speed);
            }
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                newY -= (int)Math.Round(ghost.Speed);
            }
            if (Raylib.IsKeyDown(KeyboardKey.Down))
            {
                newY += (int)Math.Round(ghost.Speed);
            }

            UpdatePosition(ghost, newX, newY, ghost.Speed);
        }

        public override void UpdatePacManPosition(BotPac botPac, Ghosts Ghosts)
        {
            int newX = botPac.PositionX;
            int newY = botPac.PositionY;

            int dx = Math.Sign(Ghosts.PositionX - botPac.PositionX);
            int dy = Math.Sign(Ghosts.PositionY - botPac.PositionY);

            newX += dx;
            newY += dy;

            UpdatePosition(botPac, newX, newY, botPac.Speed);
        }

        public override void UpdateRestartGame(Ghosts ghost)
        {
            if((Raylib.IsKeyDown(KeyboardKey.Space) && ghost.Dead) || (ghost.Won && Raylib.IsKeyDown(KeyboardKey.Space)))
            {
                ghost.Dead = false;
                ghost.Won = false;
                Random rnd = new();
                ghost.PositionX = rnd.Next(0, WindowsGame.Width);
                ghost.PositionY = rnd.Next(0, WindowsGame.Length);
            }
        }
    }
}