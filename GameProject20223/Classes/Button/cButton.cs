using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Button
{
    abstract class cButton : IUpdateable
    {
        protected Game1 _game;
        protected GraphicsDevice _graphicsDevice;
        protected ContentManager _content;

        internal Texture2D _texture;

        // Constructor 
        public cButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int X, int Y)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;


            setPos(X, Y);
            rectangle = new Rectangle(x, y, width, height);
        }

        // Grootte van de knop
        internal int width { get; set; } = 175;
        internal int height { get; set; } = 60;

        public void setSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        // Positie van de knop
        internal int x { get; set; }
        internal int y { get; set; }

        public void setPos(int X, int Y)
        {
            x = X;
            y = Y;
        }

        // Kleur property
        public Color color { get; set; } = Color.White;

        // Rechthoek over knop
        public Rectangle rectangle { get; private set; }

        // Bool of er geklikt is op knop
        public bool Clicked { get; private set; }

        // Update functie
        

        internal abstract void DoBtnFunction();

        // Teken functie
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, rectangle, color);
        }
    }
}
