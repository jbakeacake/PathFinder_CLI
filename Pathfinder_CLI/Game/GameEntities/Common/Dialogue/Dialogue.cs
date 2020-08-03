using System;

namespace Pathfinder_CLI.Game.GameEntities.Common.Dialogue
{
    public class Dialogue
    {
        public string _prompt { get; set; }
        public string _speakerName { get; set; }
        public Dialogue(string speakerName, string prompt)
        {
            _speakerName = speakerName;
            _prompt = prompt;
        }

        public void DisplayPrompt()
        {
            Console.WriteLine($"{_speakerName}: '{_prompt}'");
        }
    }
}