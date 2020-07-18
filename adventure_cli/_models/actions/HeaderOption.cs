using System.Collections.Generic;

namespace adventure_cli._models.actions
{
    public class HeaderOption
    {
        public int _index { get; set; }
        public string _name { get; set; }
        public List<Option> _sublist { get; set; }

        public HeaderOption(int index, string name, List<Option> sublist)
        {
            _index = index;
            _name = name;
            _sublist = sublist;
        }

        public string SubListToString()
        {
            string toRtn = "";
            int counter = 0;
            foreach (var option in _sublist)
            {
                if (counter == 2)
                {
                    toRtn += "\n";
                }
                toRtn += $"{option._index}.) {option._name} \t";
                counter++;
            }
            return toRtn;
        }
    }
}