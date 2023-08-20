namespace Tanks
{
    public interface IListener
    {
        public void OnEvent(EventType eventType);
    }
}