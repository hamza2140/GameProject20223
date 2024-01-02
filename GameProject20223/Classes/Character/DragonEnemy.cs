using GameProject20223.Animations;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Character
{
    public class DragonEnemy : Enemy
    {
        Animation runAnimation, attackAnimation, deathAnimation;

        public dragonEnemy(Texture2D texture, int startPos, int endPos, int height) : base(texture, startPos, endPos, height)
        {
            // Default waardes ingeven
            base.width = 32;
            base.height = 32;
            base.scale = 4;

            // Animaties ingeven.
            MakeAnimations();

            // Huidige animatie intialiseren.
            animationManager = new AnimationManager();
            animationManager.CurrentAnimation = runAnimation;
        }
    }
}
