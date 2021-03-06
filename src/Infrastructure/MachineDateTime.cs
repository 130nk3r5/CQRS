﻿using System;
using Common;

namespace Infrastructure
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public DateTime Today => DateTime.Today;
    }
}
