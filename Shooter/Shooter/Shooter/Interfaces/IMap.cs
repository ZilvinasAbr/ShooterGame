using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Classes;

namespace Shooter.Interfaces
{
    public interface IMap
    {
        Texture2D BackgroundTexture { get; set; }
        int Width { get; }
        int Height { get; }
        IList<IMapObject> MapObjects { get; set; }
        void AddMapObject(IMapObject mapObject);
        void Broadcast(string message, IMapObject sender);
    }
}
