# Project to create a PacMan

Pacman game in c# using raylib

the objective is to flee the enemies and collect all the balls to win

*Start projet*

```
dotnet build
```

```
cd ./bin/Debug
```

```
./PacMan.exe
```

## UML Schema
```mermaid
classDiagram
class ACharacter {
  <<Abstract>>
  -_name: string
  + «get; set>>() Name: string
  - «readonly» _type: string
  + endurance: int
  + force_value: int
  # agility_value: int
  + smart_value: int
  - «readonly» _NbDices: int
  - «readonly» _NbFaces: int
  + level: int
  - _experience: int
  + maxValueDamageMe: int
  + minValueDamageMe: int
  + ActionPoints: int
  +ACharacter(name: string, type: string)
  +virtual void GenerateStats()
  +void NextLevel()
  +sealed override string ToString()
  +abstract void UpgradeStats()
  + int CallFight(ACharacter opponent)
  # int Fight(ACharacter opponent)
  + void AddExperience(int experience)
  + List<IEquipment> Equipments
  + void AddEquipment(IEquipment equipment)
  + void RemoveEquipment(IEquipment equipment)
  + void UseEquipment(IEquipment equipment, ACharacter opponent)
}
ACharacter --|> IEquipment : Use
ScrollMagic --|> IEquipment
Weapon --|> IEquipment
Mage --|> ACharacter
Warrior --|> ACharacter
Ranger --|> ACharacter
BotTeacher --|> ACharacter

class IEquipment {
    <<interface>>
    +Name: String
    +ActionPoints: int
    +Range: int
    +Bonus: int
    +Use(player: ACharacter, opponent: ACharacter): void
}

class ScrollMagic {
    <<Class>>
    +Name: String
    +ActionPoints: int
    +Range: int
    +Bonus: int
    +ScrollMagic(name: String, actionPoints: int, range: int, bonus: int)
    +Use(player: ACharacter, opponent: ACharacter)
}

class Weapon {
    <<Class>>
    +Name: String
    +ActionPoints: int
    +Range: int
    +Bonus: int
    +Weapon(name: String, actionPoints: int, range: int, bonus: int)
    +Use(player: ACharacter, opponent: ACharacter)
}

class Mage {
    <<Class>>
  +Mage(name: string)
  +override void GenerateStats()
  +override void UpgradeStats()
}

class Warrior {
    <<Class>>
  +Warrior(name: string)
  +override void GenerateStats()
  +override void UpgradeStats()
}

class Ranger {
    <<Class>>
  +Ranger(name: string)
  +override void GenerateStats()
  +override void UpgradeStats()
}

class BotTeacher {
    <<Class>>
  +BotTeacher(name: string)
  +override void GenerateStats()
  +override void UpgradeStats()
}