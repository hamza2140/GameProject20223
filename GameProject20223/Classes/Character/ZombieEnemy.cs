using GameProject20223.Animations;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Character
{
    class ZombieEnemy : Enemy
    {
        Animation runAnimation, attackAnimation, deathAnimation;

        public ZombieEnemy(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            // Zombie trager maken
            base.speed.X = 2;
            base.width = 64;
            base.height = 64;
            base.scale = 2;

            // Animaties ingeven.
            CreateAnimations();

            // Huidige animatie intialiseren.
            animationManager.CurrentAnimation = runAnimation;
        }
        internal override void CreateAnimations()
        {
            // Set all the animation for the hero
            attackAnimation = new Animation();
            attackAnimation.AddSpriteRow(width, height, 0, 9);

            deathAnimation = new Animation();
            deathAnimation.AddSpriteRow(width, height, 1, 8);

            runAnimation = new Animation();
            runAnimation.AddSpriteRow(width, height, 2, 4);
        }
    }
}
