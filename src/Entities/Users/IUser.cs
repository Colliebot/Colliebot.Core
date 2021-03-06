﻿using System;

namespace Colliebot
{
    public interface IUser : ISimpleUser
    {
        string Description { get; set; }
        IconFrom AvatarFrom { get; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
        DateTime? DeletedAt { get; set; }
    }
}
