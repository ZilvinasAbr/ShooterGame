using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Classes
{
    public class Map
    {
        public Texture2D BackgroundTexture { get; set; }
        public int Width{ get; }
        public int Height { get; }
        public IList<IMapObject> MapObjects { get; set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            MapObjects = new List<IMapObject>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, Vector2.Zero, Color.White);
            foreach (var mapObject in MapObjects)
            {
                mapObject.Draw(spriteBatch);
            }
        }
    }
}
