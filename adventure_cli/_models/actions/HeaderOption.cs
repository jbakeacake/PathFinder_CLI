using System.Collections.Generic;

namespace adventure_cli._models.actions
{
    public class HeaderOption
    {
        public int _index { get; set; }
        public string _name { get; set; }
        public List<IAction> _sublist { get; set; }

        public HeaderOption(int index, string name, List<IAction> sublist)
        {
            _index = index;
            _name = name;
            _sublist = sublist;
        }
    }
}