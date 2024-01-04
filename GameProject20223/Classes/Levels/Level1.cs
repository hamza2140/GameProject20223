using GameProject20223.Classes.Character;
using GameProject20223.Classes.Collectable;
using GameProject20223.Classes.Levelsdesign;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Levels
{
    class Level1 : Level
    {
        public Level1(GraphicsDevice graphicsDevice, ContentManager content) : base(graphicsDevice, content)
        {
            // Elementen die nodig zijn in het level inladen
            stars.Add(new Star(content, 800, 650));
            stars.Add(new Star(content, 400, 400));
            stars.Add(new Star(content, 1300, 100));

            enemies.Add(new DragonEnemy(_dragonTexture, 300, 550, 25));
            enemies.Add(new ZombieEnemy(_zombieTexture, 700, 1250, 25));
            enemies.Add(new TrapEnemy(_trapTexture, 650, 650, 620));
            background = new Background(_backgroundTexture);
        }
    }
}
