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

        Raylib.InitWindow(500, 500, "PacMan Game");

        Texture2D background = Raylib.LoadTexture("assets/maps/map3-12.png");

        WindowsGame.Length = background.Height;
        WindowsGame.Width = background.Width;

        Raylib.SetWindowSize(WindowsGame.Width, WindowsGame.Length);

        Ghosts GhostsClyde = new("GhostsClyde", 1.9f, 13, 225, Raylib.LoadTexture("assets/sprites/pac/pacNarrow2.png"));
        BotPac BotPac = new("BotPac", 1.9f, 300, 400, Raylib.LoadTexture("assets/sprites/clyde.png"));
        BotPac BotPac2 = new("BotPac2", 1.9f, 250, 20, Raylib.LoadTexture("assets/sprites/blinky.png"));
        BotPac BotPac3 = new("BotPac3", 1.9f, 400, 320, Raylib.LoadTexture("assets/sprites/pinky.png"));
        BotPac BotPac4 = new("BotPac3", 1.9f, 20, 460, Raylib.LoadTexture("assets/sprites/inky.png"));
        BotPac BotPac5 = new("BotPac3", 1.9f, 410, 230, Raylib.LoadTexture("assets/sprites/blue_ghost.png"));

        GameLogic gameL = new();

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            Raylib.DrawTexture(background, 0, 0, Color.White);


            Raylib.DrawText("PX " + GhostsClyde.PositionX + " PY " + GhostsClyde.PositionY, Raylib.GetScreenWidth() / 2 - 70, Raylib.GetScreenHeight() / 2 - 20, 20, Color.White);

            gameL.DrawGhost(GhostsClyde);
            gameL.DrawGhost(BotPac);
            gameL.DrawGhost(BotPac2);
            gameL.DrawGhost(BotPac3);
            gameL.DrawGhost(BotPac4);
            gameL.DrawGhost(BotPac5);


            gameL.UpdateGhostsPosition(GhostsClyde);
            gameL.UpdatePacManPosition(BotPac, GhostsClyde);
            gameL.UpdatePacManPosition(BotPac2, GhostsClyde);
            gameL.UpdatePacManPosition(BotPac3, GhostsClyde);
            gameL.UpdatePacManPosition(BotPac4, GhostsClyde);
            gameL.UpdatePacManPosition(BotPac5, GhostsClyde);


            gameL.GhostIsDeadOrNo(BotPac, GhostsClyde);
            gameL.GhostIsDeadOrNo(BotPac2, GhostsClyde);
            gameL.GhostIsDeadOrNo(BotPac3, GhostsClyde);
            gameL.GhostIsDeadOrNo(BotPac4, GhostsClyde);
            gameL.GhostIsDeadOrNo(BotPac5, GhostsClyde);

            gameL.CheckStateGame(GhostsClyde);

            gameL.UpdateRestartGame(GhostsClyde);

            Raylib.EndDrawing();
        }
        Raylib.UnloadTexture(background);
        Raylib.UnloadTexture(GhostsClyde.Texture);
        Raylib.CloseWindow();
    }
}