using System.Threading.Tasks;

namespace Colliebot
{
    public interface IDeletable
    {
        /// <summary> Deletes this object and all its children. </summary>
        Task DeleteAsync(RequestOptions options = null);
    }
}
