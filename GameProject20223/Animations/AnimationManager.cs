﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Animations
{
    internal class AnimationManager
    {
        public AnimationFrame CurrFrame { get; set; }
        private List<AnimationFrame> frames;
        private int counter;
    }
}
