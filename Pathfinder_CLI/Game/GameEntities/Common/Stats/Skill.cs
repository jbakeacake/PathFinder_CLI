using Pathfinder_CLI.Game.GameEntities.Common.Interfaces;

namespace Pathfinder_CLI.Game.GameEntities.Common.Stats
{
    public class Skill : ISkill
    {
        public string _name { get; set; }
        public int _value { get; set; }
        public Skill(string name, int value)
        {
            _name = name;
            _value = value;
        }
        // GetModifier()
        // Returns an amount based on the number of points invested into this skill -- increases by +1 per odd number starting on 1.
        // e.g. _value = 1 to 2, return 1; _value = 3 to 4, return 2;
        public int GetModifier()
        {
            if (_value == 0)
            {
                return 0;
            }
            else if (_value >= 9) // 9 points is the current hard cap for all skills
            {
                return 5; // In line with our method below, 9 should return a +5 modifier.
            }

            int modifier = 0;

            if (_value % 2 == 1) // if odd
            {
                modifier = (_value / 2) + 1; 
            }
            else // if even
            {
                modifier = (_value / 2);
            }

            return modifier;
        }

        public string GetName()
        {
            return _name;
        }

        public int GetValue()
        {
            return _value;
        }

        public void IncreaseValueBy(int value)
        {
            _value += value;
        }
    }
}