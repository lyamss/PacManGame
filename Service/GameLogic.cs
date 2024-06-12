using PacMan.Abstract;
using Raylib_cs;

namespace PacMan.Service
{
    public static class GameLogic
    {
        private static double _moveTimer = 0.0;

        public static void UpdateGhostsPosition(AGhost ghost)
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

        public static void UpdatePacManPosition(APac botPac, AGhost Ghosts)
        {
            int newX = botPac.PositionX;
            int newY = botPac.PositionY;

            int dx = Math.Sign(Ghosts.PositionX - botPac.PositionX);
            int dy = Math.Sign(Ghosts.PositionY - botPac.PositionY);

            newX += dx;
            newY += dy;

            UpdatePosition(botPac, newX, newY, botPac.Speed);
        }

        public static void DrawGhost(ABody body)
        {
            Raylib.DrawTexture(body.Texture, body.PositionX, body.PositionY, Color.White);
        }

        public static void CheckStateGame(AGhost Ghosts)
        {
            if (Ghosts.Dead)
                WindowsGame.DrawDead();
            if (Ghosts.Won)
                WindowsGame.DrawWon();
        }

        public static void GhostIsDeadOrNo(APac botPac, AGhost Ghosts)
        {
            if (botPac.PositionX == Ghosts.PositionX && botPac.PositionY == Ghosts.PositionY)
            {
                Ghosts.Dead = true;
            }
        }

        private static void CheckPositionBeforeToUpdatePosition(ABody body, int newX, int newY)
        {
            if (newX >= 0 && newX < WindowsGame.Width && newY >= 0 && newY < WindowsGame.Length && (!body.Dead))
            {
                body.PositionX = newX;
                body.PositionY = newY;
            }
        }

        public static void UpdateRestartGame(AGhost ghost)
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

        private static void UpdatePosition(ABody body, int newX, int newY, double speed)
        {
            _moveTimer += Raylib.GetFrameTime();
            if (_moveTimer < 2.0 - speed)
                return;
            _moveTimer -= 2.0 - speed;

            CheckPositionBeforeToUpdatePosition(body, newX, newY);
        }
    }
}