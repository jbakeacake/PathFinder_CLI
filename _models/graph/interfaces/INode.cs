namespace adventure_cli._models.graph.interfaces
{
    /*
    Our implementation for a Node is going to follow the structure used to build an
    N-ary tree. In other words, each Node in our tree will have N amount of children,
    where the relationship is strictly parent-to-child.

    Each node will contain information about the setting, and contain a set of enums
    of the possible following rooms.

    Each node will act strictly as the decision-maker/controller for our player. We can
    think of this design as each node being its own minicontroller on how the player traverses
    through the game.

    -----
    Structure

    + : public
    - : private
    # : protected

    + RoomSet : HashSet<EventNode>
    + Rooms : LinkedList<SingularNode> // Contains a generated structure of "Singular Nodes" built from our possible room enums
    */
    public interface INode
    {
         
    }
}