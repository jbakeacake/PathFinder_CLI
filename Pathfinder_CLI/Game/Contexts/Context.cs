using System;
using System.Runtime.InteropServices;
using Pathfinder_CLI.Game.GameEntities.Characters;

namespace Pathfinder_CLI.Game.Contexts
{
    public abstract class Context
    {
        public PlayerEntity _player { get; set; }
        public CharacterEntity _other { get; set; }
        public string _description { get; set; }
        
        public Context(PlayerEntity player, string description)
        {
            _player = player;
            _description = description;
        }
        public Context(PlayerEntity player, [Optional] CharacterEntity other, string description)
        {
            _player = player;
            _other = other;
            _description = description;
        }

        public void PrintDescription()
        {
            Console.WriteLine(_description);
        }
    }
}