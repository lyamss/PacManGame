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

        GameLogic gameL = new();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawTexture(background, 0, 0, Color.White);


            gameL.DrawGhost(GhostsClyde);
            gameL.DrawGhost(BotPac);
            gameL.DrawGhost(BotPac2);


            gameL.UpdateGhostsPosition(GhostsClyde);
            gameL.UpdatePacManPosition(BotPac, GhostsClyde);
            gameL.UpdatePacManPosition(BotPac2, GhostsClyde);


            gameL.GhostIsDeadOrNo(BotPac, GhostsClyde);
            gameL.GhostIsDeadOrNo(BotPac2, GhostsClyde);

            gameL.CheckStateGame(GhostsClyde);

            gameL.UpdateRestartGame(GhostsClyde);

            Raylib.EndDrawing();
        }
        Raylib.UnloadTexture(background);
        Raylib.UnloadTexture(GhostsClyde.Texture);
        Raylib.CloseWindow();
    }
}