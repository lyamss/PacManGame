# Project to create a PacMan

Pacman game in c# using raylib

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


class AGhosts {
  <<abstract>>
    - _speed : double
    + double GetSpeed()
    # void SetSpeed(speed: double)
    - _positionX : int
    + int GetPositionX()
    # void SetPositionX(positionX: int)
    - _positionY : int
    + int GetPositionY()
    # void SetPositionY(positionY: int)
    - _texture : Texture2D
    + Texture2D GetTexture()
    # void SetTexture(texture: Texture2D)
    + Dead : bool
    + Won : bool
    # Name : string
    # LifePoint : int
    - _rand : Random
    + "constructor" AGhosts(name : string)
    # void "virtual" GenerateStats()
}


class APac {
  <<abstract>>
  + "constructor" APac(name : string)
}

class BotPac {
  <<class>>
  + "constructor" APac(name : string)
  # GenerateStats()
}

class BotPac2 {
  <<class>>
  + "constructor" APac(name : string)
  # GenerateStats()
}

class GhostsClyde {
  <<class>>
  + "constructor" APac(name : string)
  # GenerateStats()
}

APac --|> AGhosts
BotPac --|> APac
BotPac2 --|> APac
GhostsClyde --|> AGhosts