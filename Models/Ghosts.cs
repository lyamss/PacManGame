using PacMan.Abstract;
using Raylib_cs;

namespace PacMan.Models
{
    public class Ghosts(string name, double Speed, int PositionX, int PositionY, Texture2D Texture) : ABody(name, Speed, PositionX, PositionY, Texture) { }
}