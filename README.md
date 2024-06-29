# Project to create a PacMan

Pacman game in C# using raylib

the objective is to flee the enemies and collect all the balls to win

*Start projet*

```
dotnet build
```

```
cd ./bin/Debug/net8.0
```

```
./PacMan.exe
```

## UML Schema
```mermaid
classDiagram


class ABody {
  <<abstract>>
    - _speed : double
    + double GetSpeed()
    - void SetSpeed(speed: double)
    - _positionX : int
    + int GetPositionX()
    + void SetPositionX(positionX: int)
    - _positionY : int
    + int GetPositionY()
    + void SetPositionY(positionY: int)
    - _texture : Texture2D
    + Texture2D GetTexture()
    - void SetTexture(texture: Texture2D)
    + Dead : bool
    + Won : bool
    # Name : string
    + "constructor" ABody(name : string, double Speed, int PositionX, int PositionY, Texture2D Texture)
}

class AGameLogicBase {
  <<abstract>>
    # _moveTimer : double
    + "abstract" void UpdateGhostsPosition(Ghosts ghost)
    + "abstract" void UpdatePacManPosition(BotPac botPac, Ghosts Ghosts)
    + void DrawGhost(ABody body)
    + void CheckStateGame(Ghosts Ghosts)
    + void GhostIsDeadOrNo(BotPac botPac, Ghosts Ghosts)
    # void CheckPositionBeforeToUpdatePosition(ABody body, int newX, int newY)
    + "abstract" void UpdateRestartGame(Ghosts ghost)
    # void UpdatePosition(ABody body, int newX, int newY, double speed)
    + "constructor" AGameLogicBase()
    # gameMap : int[,]
    # bool IsWallCollision(int newX, int newY)
    # void CreateMap()
}


class IGameLogic {
  <<interface>>
    + void UpdateRestartGame(Ghosts ghost)
    + void GhostIsDeadOrNo(BotPac botPac, Ghosts Ghosts)
    + void CheckStateGame(Ghosts Ghosts)
    + void DrawGhost(ABody body)
    + void UpdatePacManPosition(BotPac botPac, Ghosts Ghosts)
    + void UpdateGhostsPosition(Ghosts ghost)
}

class GameLogic {
  <<class>>
    + "override" void UpdateGhostsPosition(Ghosts ghost)
    + "override" void UpdatePacManPosition(BotPac botPac, Ghosts Ghosts)
    + "override" void UpdateRestartGame(Ghosts ghost)
}


class BotPac {
  <<class>>
  + "constructor" BotPac(name : string, double Speed, int PositionX, int PositionY, Texture2D Texture)
}

class Ghosts {
  <<class>>
  + "constructor" Ghosts(name : string, double Speed, int PositionX, int PositionY, Texture2D Texture)
}

BotPac --|> ABody
Ghosts --|> ABody
GameLogic --|> AGameLogicBase
AGameLogicBase --|> IGameLogic