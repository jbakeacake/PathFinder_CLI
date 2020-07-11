namespace adventure_cli._models.entities.characters.attributes.stat_types
{
    public class Stat
    {
        private string _name { get; set; }
        public int _value { get; set; }
        public Stat(string name, int value)
        {
            _name = name;
            _value = value;
        }

        /**
        GetModifier(void) -> int

        This method gets returns the addition damage per the user's value in Strength. Every increase that results in an
        odd number will return an increase in damage (see example below).

        0 >> No modifier
        1 >> +1 modifier
        2 >> +1 modifier
        3 >> +2 modifier
        4 >> +2 modifier
        5 >> +3 modifier
        6 >> +3 modifier
        ...
        9 >> +5 modifier
        */
        public int GetModifier()
        {
            if (_value == 0) return 0;
            int modifier;

            if (_value % 2 == 1)
            {
                modifier = (_value / 2) + 1; // If the _value is odd, then divide by two, floor it, then add 1.
            }
            else
            {
                modifier = (_value / 2); // If the _value is even, then only divide by two.
            }

            return modifier;
        }

        public void IncreaseValueBy(int value)
        {
            _value += value;
        }

        public override string ToString()
        {
            return $"{_name} : {_value}";
        }
    }
}