using GameProject20223.Animations;
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

            

            // Huidige animatie intialiseren.
            animationManager = new AnimationManager();
            SetCurrentAnimation(staticAnimation);

        }

        void SetCurrentAnimation(Animation animation)
        {
            animationManager.CurrentAnimation = animation;
        }
    }
}
