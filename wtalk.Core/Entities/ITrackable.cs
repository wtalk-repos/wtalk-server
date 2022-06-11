﻿using System;

namespace Wtalk.Core.Entities
{
    public interface ITrackable
    {
       public  DateTime CreatedAt { get; set; }
       public DateTime UpdatedAt { get; set; }
    }
}
