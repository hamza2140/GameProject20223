using GameProject20223.Animations;
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

        public zombieEnemy(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            // Zombie trager maken
            base.speed.X = 2;
            base.width = 64;
            base.height = 64;
            base.scale = 2;

            // Animaties ingeven.
            MakeAnimations();

            // Huidige animatie intialiseren.
            animationManager.CurrentAnimation = runAnimation;
        }
    }
}
