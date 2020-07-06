# PathFinder_CLI | Develop
A command line interface/development version for a dungeon, rogue-lite app I plan on fleshing out into a web application later on. This version delves into the technical aspects of the application (backend) while utilizing a simple CLI to operate (frontend).

# Quick Start

To run the application, start by opening up the directory ```../path/to/adventure_cli/``` and then type ```dotnet run``` into your CLI. Your CLI should prompt you on what to do next.

# Design Outline

## User Stories
This section goes over all the functionalities that critical for the User's experience. This can include how the user interacts with the CLI, quality of life (QOL) features,
and even basic necessities (e.g. dumping out the available commands, checking stats, using items, etc.).

- [ ] User can dump available commands using a '-h' or '-help' flag.
- [ ] General Commands:
  - [ ] save : saves the user's current position in the graph
  - [ ] exit : saves then exits the user from the game
  - [ ] check <entity> : prints out all available information of an entity
    - [ ] Health : prints Current HP / Max HP
    - [ ] Inventory : prints all items in Inventory, and Available Slots / Max Slots
    - [ ] Stats : prints all stats of the user (Const, Str, Dex, Intelligence)
  - [ ] use <item> : utilizes an item in a user's inventory
- [ ] Path Commands:
  - [ ] Path <direction> : traverses the user down the path (left or right, through or around, under or over, etc.)
- [ ] Combat Commands:
  - [ ] Attack <weapon> : Attacks the opponent with a weapon
  - [ ] Block <shield/dodge> : Blocks/Dodges an incoming attack
  - [ ] Magic <spell> : casts a spell that the user knows
- [ ] Shop Commands:
  - [ ] check <entity> : prints details about the item, and its cost
  - [ ] buy <item> : buys an item in a shop node
  - [ ] sell <item> : sells an item in the inventory
  - [ ] heal : refills the user's health

## _Models

### ../graphs/DecisionNode.cs
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
private | void | ToNextRoom | void | Called when the user enters the next room; Points ```Current``` to our ```Next```; Points ```Next``` to ```Next.Next```
public | DecisionNode | SkipToNext | void | Returns the next decision node this node is pointing at

