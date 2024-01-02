using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Collectable
{
    public class Star
    {
        Texture2D startTexture;
        private bool collected;

        private int x { get; set; }
        private int y { get; set; }

        private int size { get; set; }

        public Rectangle rectangle;
    }
}
