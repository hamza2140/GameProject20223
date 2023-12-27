using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Animations
{
    internal class AnimationFrame
    {
        public Rectangle srcRectangle { get; set; }

        public AnimationFrame(Rectangle srcRectangle)
        {
            this.srcRectangle = srcRectangle;
        }
    }
}
