﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_Game.Geometry
{
    public interface ILocation
    {
        long X { get; }
        long Y { get; }

        void Fix();
    }
}
