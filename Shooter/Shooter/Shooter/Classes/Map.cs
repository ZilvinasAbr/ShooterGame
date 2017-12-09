using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Interfaces;

namespace Shooter.Classes
{
    public class Map : IMap
    {
        public Texture2D BackgroundTexture { get; set; }
        public int Width{ get; }
        public int Height { get; }
        public IList<IMapObject> MapObjects { get; set; }

        public void AddMapObject(IMapObject mapObject)
        {
            MapObjects.Add(mapObject);
            mapObject.Map = this;
        }

        public void Broadcast(string message, IMapObject sender)
        {
            foreach (var mapObject in MapObjects)
            {
                if (sender != mapObject)
                {
                    mapObject.Receive(message);
                }
            }
        }

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
