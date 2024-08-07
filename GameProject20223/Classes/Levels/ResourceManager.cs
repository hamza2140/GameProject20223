using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject20223.Classes.Levels
{
    public class ResourceManager
    {
        private static ResourceManager _instance;
        private ContentManager _content;

        private ResourceManager(ContentManager content)
        {
            _content = content;
        }

        public static ResourceManager Instance(ContentManager content)
        {
            if (_instance == null)
            {
                _instance = new ResourceManager(content);
            }
            return _instance;
        }

        public Texture2D LoadTexture(string assetName)
        {
            return _content.Load<Texture2D>(assetName);
        }
    }
}
