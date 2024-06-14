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