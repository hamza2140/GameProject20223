﻿using GameProject20223.Classes.Character;
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
    class Level2 : Level
    {
        public Level2(GraphicsDevice graphicsDevice, ContentManager content) : base(graphicsDevice, content)
        {
            // Elementen die nodig zijn in het level inladen
            stars.Add(new Star(content, 50, 700));
            stars.Add(new Star(content, 1300, 100));

            enemies.Add(new DragonEnemy(_dragonTexture, 670, 800, 60));
            enemies.Add(new ZombieEnemy(_zombieTexture, 300, 500, 25));
            background = new Background(_backgroundTexture);
        }
    }
}
