﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Levelsdesign
{
    public class MainMap
    {
        private List<CollisionBlocks> collisionTiles = new List<CollisionBlocks>();
        public List<CollisionBlocks> CollisionTiles
        {
            get { return collisionTiles; }
        }

        private int width, height;
        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public void Generate(int[,] map, int size)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int nr = map[y, x];

                    if (nr > 0)
                    {
                        CollisionTiles.Add(new CollisionBlocks(nr, new Rectangle(x * size, y * size, size, size)));
                    }

                    width = (x + 1) * size;
                    height = (y + 1) * size;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (CollisionBlocks tile in CollisionTiles)
            {
                tile.Draw(spriteBatch);
            }
        }
    }
}

