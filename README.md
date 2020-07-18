# PathFinder_CLI | Develop
A command line interface/development version for a dungeon, rogue-lite app I plan on fleshing out into a web application later on. This version delves into the technical aspects of the application (backend) while utilizing a simple CLI to operate (frontend).

# Quick Start

To run the application, start by opening up the directory ```../path/to/adventure_cli/``` and then type ```dotnet run``` into your CLI. Your CLI should prompt you on what to do next.

# Design Outline

## User Stories
This section goes over all the functionalities that critical for the User's experience. This can include how the user interacts with the CLI, quality of life (QOL) features,
and even basic necessities (e.g. dumping out the available commands, checking stats, using items, etc.).

- [ ] Users are prompted with, at most, 5 different choices that are prepended with numbers. These choices depend on the type of room that the user is in. For instance, if the user is prompted with two  different paths, then the user will be prompted with 2 different choices on their screen (e.g. 1.) Go Left 2.) Go Right). Below are some static pre-made choices the user could make
  - [ ] Combat Choices:
    - [ ] 1. Attack
    - [ ] 2. Dodge/Defend
    - [ ] 3. Spells
    - [ ] 4. Inventory
    - [ ] 5. Flee
  - [ ] Adventuring Choices -- these choices will be completely dependent on the dungeon/room event the user is in.
  - [ ] Shop Choices:
    - [ ] Sell
      - [ ] <Inventory Item 1>
      - [ ] <Inventory Item 2>
      - [ ] <Inventory Item N> (where N is the max. space in a user's inventory)
    - [ ] Buy
      - [ ] <Shop Item 1>
      - [ ] <Shop Item 2>
      - [ ] <Shop Item N> (where N is max. number of items in the shop)
  - [ ] Level Up Choices:
    - [ ] Strength
    - [ ] Dexterity
    - [ ] Intelligence
 - [ ] Users also have access to general commands such as:
   - [x] save
   - [x] exit
   - [x] inventory
   - [x] stats
   - [x] use < item >
# \_Models

### DecisionNode : INode
Our implementation for a Node is going to follow the structure used to build an
N-ary tree. In other words, each Node in our tree will have N amount of children,
where the relationship is strictly parent-to-child.

Each node will contain information about the setting, and contain a set of enums
of the possible following rooms.

Each node will act strictly as the decision-maker/controller for our player. We can
think of this design as each node being its own minicontroller on how the player traverses
through the game.

#### DecisionNode Structure
KEYWORD | TYPE | LABEL | GET | SET | DESC.
--------|------|-------|-----|-----|------
private | HashSet<RoomEvent> | RoomSet | No | No | List of enums that have been used in constructing our list of Rooms for this decision node.
private | LinkedList<INode> | Rooms | No | No | List of constructed rooms that a user will pass through if they decide this path
public | RoomEvent[] | PossibleEvents | Yes | Yes | List of all possible events that could occur in the ```Rooms``` of this path
public | bool | CanSkip | Yes | Yes | Describes whether the user can ignore this path, and move on to the next decision node
public | DecisionNode | Next | Yes | Yes | The next node in our graph that will traverse our user farther down the path (moreso than if they chose the dungeons path
public | INode | Current | Yes | Yes | The current Node the user is in -- by default is pointing at head of ```Rooms```

#### DecisionNode Methods
KEYWORD | RETURN | NAME | PARAMETERS | DESC.
--------|--------|------|------------|------
private | void | ConstructRooms | void | Called when the node is initialized; Randomly generates a set of rooms given a list of ```RoomEvent``` enums.
private | void | ToNextRoom | void | Called when the user enters the next room; Points ```Current``` to ```Current.Next```
public | DecisionNode | SkipToNext | void | Returns the next decision node this node is pointing at

## Entities

### Entity
An entity acts as a blanket class for any items, objects, or characters that a player can interact with. Each entity should have an ID number, a name, and should describe whether the entity is interactable or not (if the user can use any verbal commands on an object).

Some Entities that are derived from this class are:
- CharacterEntity.cs
- PlayerEntity.cs
- Equipable.cs
- Consumable.cs

#### Entity Structure
KEYWORD | TYPE | LABEL | GET | SET | DESC.
--------|------|-------|-----|-----|------
public | int | \_Id | Yes | No | The Id of this entity
public | string | \_name | Yes | Yes | The name of the entity
public | bool | \_interactable | Yes | Yes | Describes whether a user can perform actions on the entity

### CharacterEntity : Entity
A CharacterEntity is any entity that a user can interact with verbally or combatively, and additionally is used to create the user as well. This includes NPCs, Enemies, and the Player itself. Every entity should include an Id, Name, interactable bool, level, stats, and inventory. These data for each entity can be found on the CharacterData table on our database.

Some CharacterEntities that are derived from this class are:
- PlayerEntity.cs
- EnemyEntity.cs
- NonPlayerEntity.cs

#### CharacterEntity Structure
KEYWORD | TYPE | LABEL | GET | SET | DESC.
--------|------|-------|-----|-----|------
public | int | \_Id | Yes | No | The Id of this entity
public | string | \_name | Yes | Yes | The name of the entity
public | bool | \_interactable | Yes | Yes | Describes whether a user can perform actions on the entity
public | int | \_XP | Yes | Yes | The total, current amount of XP this entity has
public | int | \_level | Yes | Yes | The level calculated by dividing \_XP by 100
public | Stats | \_stats | Yes | Yes | A Collection of Stats that this entity has (Skills, ArmorClass, SpellSlots, etc.)
public | Inventory | \_inventory | Yes | Yes | The inventory of the entity; contains an assortment of Items (consumable, armor, weapon, etc.)

#### CharacterEntity Methods
KEYWORD | RETURN | NAME | PARAMETERS | DESC.
--------|--------|------|------------|------
public | void | printNameAndLevel | void | Prints the ```_name``` and ```_level``` of this CharacterEntity
private | void | printStats | void | Prints every ```Stat``` and Stats variable of this entity.
public | void | printInventory | void | Iterates and prints the CharacterEntity's inventory.

## Attributes

### Stats
Stats is a list of a CharacterEntity's basic attributes such as HP, XP, level, Skills, ArmorClass, Speed, and SpellSlots. In the most basic sense, Stats acts as a datasack for an entity's basic attributes.

#### Stats Structure
KEYWORD | TYPE | LABEL | GET | SET | DESC.
--------|------|-------|-----|-----|------
public | int | \_maxHP | Yes | Yes | The Maximum HP this entity can have
public | int | \_HP | Yes | Yes | The Current HP of this entity
public | int | \_XP | Yes | Yes | The total, current amount of XP this entity has
public | int | \_level | Yes | Yes | The level calculated by dividing \_XP by 100
public | Dictionary<string, Stat> | \_skills | Yes | Yes | A dictionary of an entity's basic skills (Str, Dex, Int)
public | int | \_armorClass | Yes | Yes | The ArmorClass rating is based purely on Strength + AC of Armor (e.g. Plate has +5 AC, Leather has +3 AC)
public | int | \_speed | Yes | Yes | The speed is based purely on dexterity (Dex. Modifier of 1 gives +1 Speed)
public | int | \_spellSlots | Yes | Yes | The number of spell Slots is based purely on intelligence (Int. Modifier of 2 gives 2 spell slots)

#### Stats Methods
KEYWORD | RETURN | NAME | PARAMETERS | DESC.
--------|--------|------|------------|------
public | void | IncreaseSkill | string skillName, int points | Increase a skill (Str, Dex, Int) by a certain amount of ```points```
private | void | UpdateBaseStats | void | Update other stats variables (armorClass, speed, and spellSlots) based on the modifiers of an entity's ```_skills```
