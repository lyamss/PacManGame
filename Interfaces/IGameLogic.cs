using PacMan.Abstract;
using PacMan.Models;

namespace PacMan.Interfaces
{
    public interface IGameLogic
    {
        void UpdateRestartGame(Ghosts ghost);
        void GhostIsDeadOrNo(BotPac botPac, Ghosts Ghosts);
        void CheckStateGame(Ghosts Ghosts);
        void DrawGhost(ABody body);
        void UpdatePacManPosition(BotPac botPac, Ghosts Ghosts);
        void UpdateGhostsPosition(Ghosts ghost);
    }
}