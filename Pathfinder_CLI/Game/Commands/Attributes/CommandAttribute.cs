using System;

namespace Pathfinder_CLI.Game.Commands.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class CommandAttribute : Attribute
    {
        public string Text { get; }
        public CommandAttribute(string text)
        {
            Text = text;
        }        
    }
}