using GameProject20223.Classes.Character;
using GameProject20223.Classes.Collectable;
using GameProject20223.Classes.Levelsdesign;
using GameProject20223.Interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Levels
{
    class LevelOne : MainLevel
    {
        public LevelOne(GraphicsDevice graphicsDevice, ContentManager content) : base(graphicsDevice, content)
        {
            // ResourceManager singleton instance
            var resourceManager = ResourceManager.Instance(content);

            // Adding NinjaStars
            ninjaStars.Add(new NinjaStar(resourceManager.LoadTexture("star"), 800, 650));
            ninjaStars.Add(new NinjaStar(resourceManager.LoadTexture("star"), 400, 400));
            ninjaStars.Add(new NinjaStar(resourceManager.LoadTexture("star"), 1300, 100));

            // Using factories to create enemies
            IEnemyFactory animalFactory = new AnimalEnemyFactory();
            IEnemyFactory zombieFactory = new ZombieEnemyFactory();
            IEnemyFactory trapFactory = new TrapEnemyFactory();

            enemies.Add(animalFactory.CreateEnemy(resourceManager.LoadTexture("enemy"), 300, 550, 25));
            enemies.Add(zombieFactory.CreateEnemy(resourceManager.LoadTexture("zombie"), 700, 1250, 25));
            enemies.Add(trapFactory.CreateEnemy(resourceManager.LoadTexture("skull"), 400, 900, 25));

            // Setting background
            background = new Background(resourceManager.LoadTexture("background"));
        }
        public override void GenerateLevel()
        {
            map = new MainMap();

            // 1 = Cobble met mos
            // 2 = Cobble
            // 3 = Steen

            map.Generate(new int[,]
            {
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,3,3,3,3,3,0,0,0,3,1},
                {1,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,3,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,1},
                {1,0,0,0,0,2,2,2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,2,2,2,2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,1},
                {1,0,0,2,2,2,2,2,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            }, 40);
        }
    }
}
