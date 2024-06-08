using Raylib_cs;
using PacMan.Models;
using PacMan.Service;

namespace PacMan;

class Program
{
    static Texture2D background;

    static void Main(string[] args)
    {
        ReadParameters.SelectParam(args);

        Raylib.InitWindow(460, 506, "PacMan Game");

        background = Raylib.LoadTexture("assets/maps/map3-12.png");

        PacHandsomeGuy PacHandsomeGuy = new("PacHandsomeGuy");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            Raylib.DrawTexture(background, 0, 0, Color.White);

            Raylib.DrawRectangle(PacHandsomeGuy.CharacterX, PacHandsomeGuy.CharacterY, PacHandsomeGuy.CharacterWidth, PacHandsomeGuy.CharacterHeight, PacHandsomeGuy.Color);


            if (Raylib.IsKeyDown(KeyboardKey.Right))
            {
                PacHandsomeGuy.CharacterX += (int)Math.Round(PacHandsomeGuy.CharacterSpeed);
                if (PacHandsomeGuy.CharacterX + PacHandsomeGuy.CharacterWidth > 800)
                {
                    PacHandsomeGuy.CharacterX = 0;
                }
            }
            else if (Raylib.IsKeyDown(KeyboardKey.Left))
            {
                PacHandsomeGuy.CharacterX -= (int)Math.Round(PacHandsomeGuy.CharacterSpeed);
                if (PacHandsomeGuy.CharacterX < 0)
                {
                    PacHandsomeGuy.CharacterX = 800 - PacHandsomeGuy.CharacterWidth;
                }
            }
            if (Raylib.IsKeyDown(KeyboardKey.Up))
            {
                PacHandsomeGuy.CharacterY -= (int)Math.Round(PacHandsomeGuy.CharacterSpeed);
                if (PacHandsomeGuy.CharacterY < 0)
                {
                    PacHandsomeGuy.CharacterY = 480 - PacHandsomeGuy.CharacterHeight;
                }
            }
            else if (Raylib.IsKeyDown(KeyboardKey.Down))
            {
                PacHandsomeGuy.CharacterY += (int)Math.Round(PacHandsomeGuy.CharacterSpeed);
                if (PacHandsomeGuy.CharacterY + PacHandsomeGuy.CharacterHeight > 480)
                {
                    PacHandsomeGuy.CharacterY = 0;
                }
            }

            Raylib.EndDrawing();
        }
        Raylib.UnloadTexture(background);
        Raylib.CloseWindow();
    }
}