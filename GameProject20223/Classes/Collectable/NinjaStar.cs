using GameProject20223.Character;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Collectable
{
    public class NinjaStar
    {
        Texture2D startTexture;
        private bool collected;

        private int x { get; set; }
        private int y { get; set; }

        private int size { get; set; }

        public Rectangle rectangle;
        public NinjaStar(ContentManager content, int xPos, int yPos)
        {
            x = xPos;
            y = yPos;

            size = 50;

            startTexture = content.Load<Texture2D>("star");
            rectangle = new Rectangle(xPos, yPos, size, size);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!collected)
            {
                spriteBatch.Draw(startTexture, rectangle, Color.White);
            }
        }

        public void Collected()
        {
            // Coin is opgenomen
            collected = true;

            // Uit scherm halen
            rectangle.Y = -500;

            // Score verhogen
            Hero.score += 1;
        }
    }
}
