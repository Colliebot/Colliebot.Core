using System;

namespace Colliebot
{
    public interface IEntity<TId>
        where TId : IEquatable<TId>
    {
        /// <summary> Gets the ICollieClient that created this object. </summary>
        ICollieClient Client { get; }
        /// <summary> Gets the unique identifier for this object. </summary>
        TId Id { get; }
    }
}
