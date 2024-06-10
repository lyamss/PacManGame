using Raylib_cs;
using PacMan.Models;
using PacMan.Service;

namespace PacMan;

class Program
{
    static void Main(string[] args)
    {
        ReadParameters.SelectParam(args);
        Raylib.SetTraceLogLevel(TraceLogLevel.Fatal);

        Raylib.InitWindow(WindowsGame.Width, WindowsGame.Length, "PacMan Game");

        Texture2D background = Raylib.LoadTexture("assets/maps/map3-12.png");

        WindowsGame.Length = background.Height;
        WindowsGame.Width = background.Width;

        Raylib.SetWindowSize(WindowsGame.Width, WindowsGame.Length);

        GhostsClyde GhostsClyde = new("GhostsClyde");
        BotPac BotPac = new("BotPac");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawTexture(background, 0, 0, Color.White);

            GameLogic.DrawGhost(GhostsClyde);
            GameLogic.DrawGhost(BotPac);
            GameLogic.UpdateGhostPosition(GhostsClyde);
            GameLogic.UpdatePacManPosition(BotPac, GhostsClyde);
            GameLogic.GhostIsDeadOrNo(BotPac, GhostsClyde);
            GameLogic.CheckStateGame(GhostsClyde);

            Raylib.EndDrawing();
        }
        Raylib.UnloadTexture(background);
        Raylib.UnloadTexture(GhostsClyde.Texture);
        Raylib.CloseWindow();
    }
}