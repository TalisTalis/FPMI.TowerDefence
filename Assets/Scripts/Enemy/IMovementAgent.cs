using Field;

namespace Assets
{
    public interface IMovementAgent
    {
        void TickMovement();
        
        // в какой ноде находится агент
        Node GetCurrentNode();
    }
}
