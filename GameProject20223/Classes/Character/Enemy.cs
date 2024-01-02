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

        public Enemy(Texture2D texture, int startPos, int endPos, int height)
        {
            end = endPos;
            start = startPos;

            isAlive = true;

            enemyTexture = texture;

            speed = new Vector2(3, 3);
            position = new Vector2(startPos, (700 - height));

            // Huidige animatie intialiseren.
            animationManager = new AnimationManager();
        }
    }
}
