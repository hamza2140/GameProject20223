﻿using GameProject20223.Animations;
using GameProject20223.Character;
using GameProject20223.Classes.Interfaces;
using GameProject20223.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDrawable = GameProject20223.Classes.Interfaces.IDrawable;
using IUpdateable = GameProject20223.Interfaces.IUpdateable;

namespace GameProject20223.Classes.Character
{
    abstract class Enemy: IDrawable, IUpdateable, IDead
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
        internal abstract void CreateAnimations();

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isAlive)
            {
                spriteBatch.Draw(enemyTexture, position, animationManager.CurrentAnimation.CurrFrame.srcRectangle,
                Color.White, 0f, new Vector2(0, 0), scale, se, 0f);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (isAlive)
            {
                MoveX();

                // Rectangle opnemen voor collisions
                rectangle = new Rectangle((int)position.X + 50, (int)position.Y + height, 32 - 10, 32);
                // Animatie updaten
                animationManager.CurrentAnimation.Update(gameTime);
            }
        }
        public virtual void MoveX()
        {
            // Variabelen initialiseren
            position.X += speed.X;

            // Enemey mag niet verder dan eindpositie
            if (position.X >= end)
            {
                speed.X *= -1;
                se = SpriteEffects.FlipHorizontally;
            }

            // Enemy mag niet verder dan startpositie
            if (position.X <= start)
            {
                speed.X *= -1;
                se = SpriteEffects.None;
            }
        }
        public void Die()
        {
            //Dood animatie..

            // Enemy sterft
            isAlive = false;

            // Uit scherm
            rectangle.Y = -500;

            // Hero score gaat omhoog
            Hero.score += 1;
        }
    }
}
