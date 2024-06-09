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

            if (newX >= 0 && newX < WindowsGame.Width && newY >= 0 && newY < WindowsGame.Length)
            {
                ghost.PositionX = newX;
                ghost.PositionY = newY;
            }
        }

        public static void DrawGhost(GhostsClyde ghost)
        {
            Raylib.DrawTexture(GhostsClyde.Texture, ghost.PositionX, ghost.PositionY, Color.White);
        }


        public static void CheckStateGame()
        {
            if (GhostsClyde.Dead)
                WindowsGame.DrawDead();
            if (GhostsClyde.Won)
                WindowsGame.DrawWon();
        }
    }
}