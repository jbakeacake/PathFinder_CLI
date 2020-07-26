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
  - [ ] check < entity > : prints out all available information of an entity
    - [ ] Health : prints Current HP / Max HP
    - [ ] Inventory : prints all items in Inventory, and Available Slots / Max Slots
    - [ ] Stats : prints all stats of the user (Const, Str, Dex, Intelligence)
  - [ ] use < item > : utilizes an item in a user's inventory
- [ ] Path Commands:
  - [ ] Path < direction > : traverses the user down the path (left or right, through or around, under or over, etc.)
- [ ] Combat Commands:
  - [ ] Attack < weapon > : Attacks the opponent with a weapon
  - [ ] Block < shield/dodge > : Blocks/Dodges an incoming attack
  - [ ] Magic < spell > : casts a spell that the user knows
- [ ] Shop Commands:
  - [ ] check <entity> : prints details about the item, and its cost
  - [ ] buy <item> : buys an item in a shop node
  - [ ] sell <item> : sells an item in the inventory
  - [ ] heal : refills the user's health


Documentation is being drafted at the moment. Check it out later for any updates!