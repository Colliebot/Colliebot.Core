namespace Colliebot
{
    public interface ITwitchUser : IUser
    {
        ulong TwitchId { get; }
        string Username { get; }
        string AvatarUrl { get; }
    }
}
