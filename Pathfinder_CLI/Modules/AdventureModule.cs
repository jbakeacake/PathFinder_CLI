using System;
using Pathfinder_CLI.Game.Commands.Attributes;
using Pathfinder_CLI.Game.Contexts;
using Pathfinder_CLI.Game.GameEntities.Characters;

namespace Pathfinder_CLI.Modules
{
    public class AdventureModule : ModuleBase<AdventureContext>
    {
        private PlayerEntity _player;

        public AdventureModule(IServiceProvider provider) : base(provider)
        {
            _player = _context._player;
        }

        [Command("left")]
        public bool Left()
        {
            if (!String.IsNullOrEmpty(_context._pathTitles[0]))
            {
                SendMessage("There is no Left path...");
                return false;
            }
            SendMessage($"You venture onwards, heading towards the {_context._pathTitles[0]}.");
            return true;
        }

        [Command("forward")]
        public bool Forward()
        {
            if (!String.IsNullOrEmpty(_context._pathTitles[2]))
            {
                SendMessage("There is no forward path...");
                return false;
            }
            SendMessage($"You plant your right foot forwards, trudging onwards toward the {_context._pathTitles[1]}");
            return true;
        }

        [Command("right")]
        public bool Right()
        {
            if (!String.IsNullOrEmpty(_context._pathTitles[2]))
            {
                SendMessage("There is no right path...");
                return false;
            }
            SendMessage($"You choose to go right -- a worthy choice -- and head towards what looks to be a {_context._pathTitles[2]}.");
            return true;
        }

        [Command("adventure", isInfoMethod: true)]
        public override bool DisplayCommands()
        {
            SendMessage(@"Here's some adventure commands you can use:
            > Left : Choose the left path
            > Forward: Choose the forward path
            > Right : Choose the right path
            ");

            return true;
        }
    }
}