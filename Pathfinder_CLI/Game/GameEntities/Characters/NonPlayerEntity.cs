using System;
using System.Collections.Generic;
using Pathfinder_CLI.Game.GameEntities.Characters.Interfaces;
using Pathfinder_CLI.Game.GameEntities.Common.Dialogue;
using Pathfinder_CLI.Game.GameEntities.Common.ItemContainers;
using Pathfinder_CLI.Game.GameEntities.Common.Stats;
using Pathfinder_CLI.Game.GameEntities.Items;

namespace Pathfinder_CLI.Game.GameEntities.Characters
{
    public class NonPlayerEntity : CharacterEntity
    {
        public Dictionary<string, DialoguePath> _dialoguePaths { get; set; }
        public NonPlayerEntity(string name, 
        string type,
        Stats stats, 
        ItemContainer inventory, 
        ItemContainer equipment, 
        Dictionary<string, DialoguePath> dialoguePaths) : base(name, type, stats, inventory, equipment)
        {
            _dialoguePaths = dialoguePaths;
        }

        public void DisplayDialogueOptions()
        {
            int counter = 1;
            foreach(var key in _dialoguePaths.Keys)
            {
                Console.WriteLine($"{counter}.) {key}");
                counter++;
            }
        }

        public DialoguePath ChooseDialogueOption(string key)
        {
            return _dialoguePaths[key];
        }
    }
}