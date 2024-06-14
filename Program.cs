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

        Ghosts GhostsClyde = new("GhostsClyde", 1.9f, 12, 230, Raylib.LoadTexture("assets/sprites/clyde.png"));
        BotPac BotPac = new("BotPac", 1.9f, 300, 400, Raylib.LoadTexture("assets/sprites/pac/pacNarrow2.png"));
        BotPac BotPac2 = new("BotPac2", 1.9f, 0, 0, Raylib.LoadTexture("assets/sprites/pac/deathAnim/death1.png"));

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawTexture(background, 0, 0, Color.White);

            GameLogic.DrawGhost(GhostsClyde);
            GameLogic.DrawGhost(BotPac);
            GameLogic.DrawGhost(BotPac2);


            GameLogic.UpdateGhostsPosition(GhostsClyde);
            GameLogic.UpdatePacManPosition(BotPac, GhostsClyde);
            GameLogic.UpdatePacManPosition(BotPac2, GhostsClyde);


            GameLogic.GhostIsDeadOrNo(BotPac, GhostsClyde);
            GameLogic.GhostIsDeadOrNo(BotPac2, GhostsClyde);

            GameLogic.CheckStateGame(GhostsClyde);

            GameLogic.UpdateRestartGame(GhostsClyde);

            Raylib.EndDrawing();
        }
        Raylib.UnloadTexture(background);
        Raylib.UnloadTexture(GhostsClyde.Texture);
        Raylib.CloseWindow();
    }
}