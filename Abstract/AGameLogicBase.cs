using PacMan.Interfaces;
using PacMan.Models;
using PacMan.Service;
using Raylib_cs;

namespace PacMan.Abstract
{
    public abstract class AGameLogicBase : IGameLogic
    {
        protected double _moveTimer = 0.0;

        public abstract void UpdateGhostsPosition(Ghosts ghost);

        public abstract void UpdatePacManPosition(BotPac botPac, Ghosts Ghosts);

        public void DrawGhost(ABody body)
        {
            Raylib.DrawTexture(body.Texture, body.PositionX, body.PositionY, Color.White);
        }

        public void CheckStateGame(Ghosts Ghosts)
        {
            if (Ghosts.Dead)
                WindowsGame.DrawDead();
            if (Ghosts.Won)
                WindowsGame.DrawWon();
        }

        public void GhostIsDeadOrNo(BotPac botPac, Ghosts Ghosts)
        {
            if (botPac.PositionX == Ghosts.PositionX && botPac.PositionY == Ghosts.PositionY)
            {
                Ghosts.Dead = true;
            }
        }

        protected void CheckPositionBeforeToUpdatePosition(ABody body, int newX, int newY)
        {
            if (newX >= 0 && newX < WindowsGame.Width && newY >= 0 && newY < WindowsGame.Length && (!body.Dead))
            {
                body.PositionX = newX;
                body.PositionY = newY;
            }
        }

        public abstract void UpdateRestartGame(Ghosts ghost);

        protected void UpdatePosition(ABody body, int newX, int newY, double speed)
        {
            _moveTimer += Raylib.GetFrameTime();
            if (_moveTimer < 2.0 - speed)
                return;
            _moveTimer -= 2.0 - speed;

            CheckPositionBeforeToUpdatePosition(body, newX, newY);
        }
    }
}