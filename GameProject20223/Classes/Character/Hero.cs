﻿using GameProject20223.Animations;
using GameProject20223.Classes;
using GameProject20223.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Character
{
    // Bron jump + gravity: Oyyou. (2012, 8 februari). XNA Tutorial 23 - Jumping and Gravity. YouTube. https://www.youtube.com/watch?v=ZLxIShw-7ac
    class Hero
    {
        // Variabelen initialiseren
        bool hasJumped, reachedTop;
        public Rectangle rectangle;

        private Texture2D heroTexture;
        private Vector2 position;
        private Vector2 speed;
        private int scale, width, height;
        private SpriteEffects se = SpriteEffects.None;

        Animation runAnimation, attackAnimation, staticAnimation, jumpAnimation, deathAnimation;
        AnimationManager animationManager;

        public static int score { get; set; }
        public bool jump { get; set; }
        public KeyboardReader inputReader { get; set; }
        public Hero(Texture2D texture, IInputReader inputReader)
        {
            heroTexture = texture;
            this.inputReader = (KeyboardReader)inputReader;

            speed = new Vector2(8, 5);
            position = new Vector2(50, 400);
            scale = 1;
            width = 64;
            height = 64;
            hasJumped = true;

            // Animaties ingeven.
            MakeAnimations();

            // Huidige animatie intialiseren.
            animationManager = new AnimationManager();
            SetCurrentAnimation(staticAnimation);

        }

        void SetCurrentAnimation(Animation animation)
        {
            animationManager.CurrentAnimation = animation;
        }
        public void Update(GameTime gameTime)
        {
            // Juiste animatie plaatsen adhv van inputReader info
            CheckAnimationToSet(inputReader.ReadMovement(), inputReader.ReadAttack());

            // Animatie updaten
            animationManager.CurrentAnimation.Update(gameTime);

            // Bewegen 
            Move();
        }

        void CheckAnimationToSet(bool moving, bool attack)
        {
            // Sprite draaien naar de richting waarheen we bewegen 
            if (inputReader.movement.HDirection == HDirection.Left)
                se = SpriteEffects.FlipHorizontally;
            if (inputReader.movement.HDirection == HDirection.Right)
                se = SpriteEffects.None;

            // Run animatie als de hero beweegd
            if (moving)
                SetCurrentAnimation(runAnimation);
            else
                SetCurrentAnimation(staticAnimation);

            // Attack animatie als we aanvallen
            if (attack)
                SetCurrentAnimation(attackAnimation);

            // Jump animation als we springen / in de lucht zijn
            if (hasJumped)
                SetCurrentAnimation(jumpAnimation);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Variabelen initialiseren
            int rotation = 0;

            // Hero tekenen
            spriteBatch.Draw(heroTexture, position, animationManager.CurrentAnimation.CurrFrame.srcRectangle,
                Color.White, rotation, new Vector2(0, 0), scale, se, 0f);
        }

        private void Move()
        {
            // Richting waarheen we gaan
            var direction = inputReader.ReadInput();

            // Richting krijgt snelheid mee
            direction *= speed;

            // Positie updaten met de richting
            position += direction;

            // Horizontale beweging 
            MoveX();

            // Verticale beweging
            Jump();
        }

        private void MoveX()
        {
            // Variabelen initialiseren
            int widthBorder = 1400;
            int rightBorder = widthBorder - width * scale;


            // Hero mag niet uit de rechterkant van het scherm lopen
            if (position.X > rightBorder)
            {
                position.X = rightBorder;
            }
            // Hero mag niet uit de linkerkant van het scherm lopen
            if (position.X < 0)
            {
                position.X = 0;
            }
        }

        private void Jump()
        {
            // Kijken of we op Jump knop hebben gedrukt
            jump = inputReader.Jump;

            // Jump instellen 
            if (speed.Y < 13)
                speed.Y += 0.4f;

            // Begin: Op jump gedrukt
            if (jump && !hasJumped && !reachedTop)
            {
                hasJumped = true;
                position.Y -= 3f;
                speed.Y = -6f;
            }

            if (position.Y + height > 787)
            {
                position.Y = 787 - height;
            }
        }

        

        private void MakeAnimations()
        {
            // Set all the animation for the hero
            runAnimation = new Animation();
            runAnimation.AddSpriteRow(width, height, 0, 11);

            attackAnimation = new Animation();
            attackAnimation.AddSpriteRow(width, height, 1, 6);

            staticAnimation = new Animation();
            staticAnimation.AddSpriteRow(width, height, 2, 6);

            jumpAnimation = new Animation();
            jumpAnimation.AddSpriteRow(width, height, 3, 3);

            deathAnimation = new Animation();
            deathAnimation.AddSpriteRow(width, height, 4, 3);
        }

        public void KilledEnemy(bool onTop)
        {
            if (onTop)
            {
                speed.Y = -5;
            }
        }
    }
}
