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
        private Texture2D starTexture;
        private bool collected;

        private int x { get; set; }
        private int y { get; set; }

        private int size { get; set; }

        public Rectangle rectangle;

        // Pas de constructor aan om een Texture2D in plaats van een ContentManager te accepteren.
        public NinjaStar(Texture2D texture, int xPos, int yPos)
        {
            starTexture = texture;
            x = xPos;
            y = yPos;

            size = 50;

            rectangle = new Rectangle(xPos, yPos, size, size);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!collected)
            {
                spriteBatch.Draw(starTexture, rectangle, Color.White);
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
