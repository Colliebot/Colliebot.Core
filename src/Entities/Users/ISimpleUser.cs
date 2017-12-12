namespace Colliebot
{
    public interface ISimpleUser : IEntity<ulong>
    {
        string Name { get; }
    }
}
