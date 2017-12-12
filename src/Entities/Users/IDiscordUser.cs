namespace Colliebot
{
    public interface IDiscordUser : IUser
    {
        ulong DiscordId { get; }
        ushort Discriminator { get; }
        string Username { get; }
        string AvatarUrl { get; }
    }
}
