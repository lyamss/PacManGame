using PacMan.Abstract;
using PacMan.Models;
using Raylib_cs;

namespace PacMan.Service
{
    public static class GameLogic
    {
        private static double _moveTimer = 0.0;

        public static void UpdateGhostPosition(GhostsClyde ghost)
        {
            _moveTimer += Raylib.GetFrameTime();
            if (_moveTimer < 1.0 - ghost.Speed)
                return;
            _moveTimer -= 1.0 - ghost.Speed;

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

            CheckPositionBeforeToUpdatePosition(ghost, newX, newY);
        }

        public static void UpdatePacManPosition(APac botPac, GhostsClyde GhostsClyde)
        {
            int newX = botPac.PositionX;
            int newY = botPac.PositionY;

            int dx = Math.Sign(GhostsClyde.PositionX - botPac.PositionX);
            int dy = Math.Sign(GhostsClyde.PositionY - botPac.PositionY);

            newX += dx;
            newY += dy;

            _moveTimer += Raylib.GetFrameTime();
            if (_moveTimer < 1.0 - botPac.Speed)
                return;
            _moveTimer -= 1.0 - botPac.Speed;

            CheckPositionBeforeToUpdatePosition(botPac, newX, newY);
        }

        public static void DrawGhost(AGhosts ghost)
        {
            Raylib.DrawTexture(ghost.Texture, ghost.PositionX, ghost.PositionY, Color.White);
        }

        public static void CheckStateGame(GhostsClyde GhostsClyde)
        {
            if (GhostsClyde.Dead)
                WindowsGame.DrawDead();
            if (GhostsClyde.Won)
                WindowsGame.DrawWon();
        }

        public static void GhostIsDeadOrNo(BotPac botPac, GhostsClyde GhostsClyde)
        {
            if (botPac.PositionX == GhostsClyde.PositionX && botPac.PositionY == GhostsClyde.PositionY)
            {
                GhostsClyde.Dead = true;
            }
        }

        public static void GhostIsDeadOrNo2(BotPac2 botPac, GhostsClyde GhostsClyde)
        {
            if (botPac.PositionX == GhostsClyde.PositionX && botPac.PositionY == GhostsClyde.PositionY)
            {
                GhostsClyde.Dead = true;
            }
        }

        private static void CheckPositionBeforeToUpdatePosition(AGhosts ghost, int newX, int newY)
        {
            if (newX >= 0 && newX < WindowsGame.Width && newY >= 0 && newY < WindowsGame.Length)
            {
                ghost.PositionX = newX;
                ghost.PositionY = newY;
            }
        }
    }
}