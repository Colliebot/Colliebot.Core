using System.Collections.Generic;
using System.Linq;

namespace Colliebot
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> collection, int offset = Constants.DefaultPageOffset, int limit = Constants.DefaultPageSize)
            => collection.Skip(offset).Take(limit);
    }
}
