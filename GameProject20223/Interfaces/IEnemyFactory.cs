using GameProject20223.Classes.Character;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Interfaces
{
    public interface IEnemyFactory
    {
        Enemy CreateEnemy(Texture2D texture, int startPos, int endPos, int height);
    }
    public class AnimalEnemyFactory : IEnemyFactory
    {
        public Enemy CreateEnemy(Texture2D texture, int startPos, int endPos, int height)
        {
            return new AnimalEnemy(texture, startPos, endPos, height);
        }
    }

    public class ZombieEnemyFactory : IEnemyFactory
    {
        public Enemy CreateEnemy(Texture2D texture, int startPos, int endPos, int height)
        {
            return new ZombieEnemy(texture, startPos, endPos, height);
        }
    }

    public class TrapEnemyFactory : IEnemyFactory
    {
        public Enemy CreateEnemy(Texture2D texture, int startPos, int endPos, int height)
        {
            return new TrapEnemy(texture, startPos, endPos, height);
        }
    }
}
