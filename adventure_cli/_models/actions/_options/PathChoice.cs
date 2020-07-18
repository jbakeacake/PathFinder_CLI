using System.Runtime.InteropServices;
using adventure_cli._models.entities.characters;
using adventure_cli._models.graph.RoadMap;

namespace adventure_cli._models.actions._options
{
    public class PathChoice : Option
    {
        public RoadMap _pathMap { get; set; }
        public PathChoice(int index, string name, RoadMap pathMap) : base(index, name)
        {
            _pathMap = pathMap;
        }

        public override void doAction(PlayerEntity player)
        {

            throw new System.NotImplementedException("Road Map not implemented yet.");
        }
    }
}