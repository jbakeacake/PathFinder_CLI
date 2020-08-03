using System;
using System.Collections.Generic;

namespace Pathfinder_CLI.Game.GameEntities.Common.Dialogue
{
    public class DialoguePath
    {
        public LinkedList<Dialogue> _path { get; set; }
        public LinkedListNode<Dialogue> _currentNode { get; set; }
        public DialoguePath(LinkedList<Dialogue> path)
        {
            _path = path;
            _currentNode = _path.First;
        }

        public void DisplayCurrentDialogue()
        {
            var dialogue = _currentNode.Value;
            dialogue.DisplayPrompt();
        }

        public void NextDialogue()
        {
            if(_currentNode.Next == null)
            {
                _currentNode = _path.First;
                return;
            }
            _currentNode = _currentNode.Next;
        }
    }
}