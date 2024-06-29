using Raylib_cs;

namespace PacMan.Service
{
    public static class WindowsGame
    {
        public static int Width { get; set; } = 0;

        public static int Length { get; set; } = 0;

        public static void DrawDead()
        {
            Raylib.DrawText("You are dead! Tap Espace to restart", Raylib.GetScreenWidth() / 2 - 70, Raylib.GetScreenHeight() / 2 - 20, 20, Color.White);
        }

        public static void DrawWon()
        {
            Raylib.DrawText("You won! Tap Espace to restart :)", Raylib.GetScreenWidth() / 2 - 40, Raylib.GetScreenHeight() / 2 - 20, 20, Color.White);
        }
    }
}