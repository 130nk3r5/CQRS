﻿using System;

namespace Common
{
    public interface IDateTime
    {
        DateTime Now { get; }

        DateTime Today { get; }
    }
}