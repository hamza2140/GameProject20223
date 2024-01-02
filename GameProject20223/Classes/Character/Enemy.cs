using GameProject20223.Animations;
using GameProject20223.Classes.Interfaces;
using GameProject20223.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Character
{
    abstract class Enemy: IDrawable, IUpdateable, IDieable
    {
        public Rectangle rectangle;
        public bool isAlive { get; private set; }

        internal Vector2 position, speed;
        internal SpriteEffects se = SpriteEffects.None;

        internal Texture2D enemyTexture;
        internal AnimationManager animationManager;

        private int start, end;
        internal int width, height, scale;
    }
}
