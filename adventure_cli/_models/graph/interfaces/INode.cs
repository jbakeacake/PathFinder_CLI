using adventure_cli._models.events;

namespace adventure_cli._models.graph.interfaces
{
    /*
    INode : Interface

    Objects that implement this interface are purely dumb data sacks. They hold information regarding the 'event' that takes place
    in the node's room. Event data contains the setting and any interactable entities (enemies, chests, doors, obstacles, etc.).
    The event data also contains how much experience the user should be get after they complete the room, as well as treasures.

    This is a contract that any classes that implement this interface must contain the following methods:

    > GetRoomEvent(void) -> RoomEvent // Gets the event occuring in this node's room
    */
    public interface INode
    {
        RoomEvent GetRoomEvent();
    }
}