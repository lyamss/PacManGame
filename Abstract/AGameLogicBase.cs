using PacMan.Interfaces;
using PacMan.Models;
using PacMan.Service;
using Raylib_cs;

namespace PacMan.Abstract
{
    public abstract class AGameLogicBase : IGameLogic
    {
        public AGameLogicBase() 
        {
            CreateMap();
        }

        protected double _moveTimer = 0.0;

        protected int[,] gameMap;

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
            if (!IsWallCollision(newX, newY) && (!body.Dead))
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

        protected bool IsWallCollision(int newX, int newY)
        {
            // check wall high & RIGHT

            if (newX < 0 || newX >= WindowsGame.Width - 40 || newY < 0 || newY >= WindowsGame.Length - 40)
            {
                return true;
            }

            if (gameMap[newX / 12, newY / 12] == 0)
            {
                return true;
            }

            return false;
        }

        protected void CreateMap()
        {
            gameMap = new int[WindowsGame.Width, WindowsGame.Length];

            for (int i = 0; i < WindowsGame.Width; i++)
            {
                for (int j = 0; j < WindowsGame.Length; j++)
                {
                    gameMap[i, j] = 1;
                }
            }

            // check wall left & down

            for (int i = 0; i < WindowsGame.Width; i++)
            {
                gameMap[i, 0] = 0;
                gameMap[i, WindowsGame.Length - 1] = 0;
            }

            for (int j = 0; j < WindowsGame.Length; j++)
            {
                gameMap[0, j] = 0;
                gameMap[WindowsGame.Width - 1, j] = 0;
            }

            // adding hard walls in the code

            for(int i = 29; i < 75; i++)
            {
                gameMap[i / 12, 333 / 12] = 0;
                Raylib.DrawRectangle(i, 333, 10, 10, Color.White);
            }
            for (int i = 29; i < 75; i++)
            {
                gameMap[i / 12, 350 / 12] = 0;
                Raylib.DrawRectangle(i, 350, 10, 10, Color.White);
            }
        }
    }
}