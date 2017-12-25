using System.Threading.Tasks;

namespace Colliebot
{
    public interface ICollieClient
    {
        ConnectionState ConnectionState { get; }

        Task StartAsync();
        Task StopAsync();
    }
}
