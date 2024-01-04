using GameProject20223.Classes.Character;
using GameProject20223.Classes.Collectable;
using GameProject20223.Classes.Levelsdesign;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using Background = GameProject20223.Classes.Levelsdesign.Background;

namespace GameProject20223.Classes.Levels
{
    public abstract class MainLevel
    {
        public MainMap map;
        public List<NinjaStar> ninjaStars;
        public int MaxScore
        {
            get { return enemies.Count + ninjaStars.Count; }
        }

        internal Background background;
        internal Texture2D _backgroundTexture, _animalTexture, _zombieTexture, _trapTexture;
        internal List<Enemy> enemies;
        internal ContentManager _content;
        internal GraphicsDevice _graphicsDevice;

        public MainLevel(GraphicsDevice graphicsDevice, ContentManager content)
        {
            // Initialisatie
            _content = content;
            _graphicsDevice = graphicsDevice;

            enemies = new List<Enemy>();
            ninjaStars = new List<NinjaStar>();

            // Textures inladen
            _animalTexture = _content.Load<Texture2D>("enemy");
            _zombieTexture = _content.Load<Texture2D>("zombie");
            _trapTexture = _content.Load<Texture2D>("skull");
            _backgroundTexture = _content.Load<Texture2D>("background");

            // Level genereren
            GenerateLevel();
        }
        public abstract void GenerateLevel();
        public void Update(GameTime gameTime)
        {
            foreach (var enemy in enemies)
                enemy.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            map.Draw(spriteBatch);

            foreach (var enemy in enemies)
                enemy.Draw(spriteBatch);

            foreach (var star in ninjaStars)
                star.Draw(spriteBatch);
        }
    }

}
