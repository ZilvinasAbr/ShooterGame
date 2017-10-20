using System.Collections.Generic;

namespace Shooter.Classes
{
    public class Map
    {
        public int Width{ get; }
        public int Height { get; }
        public IList<IMapObject> MapObjects { get; set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            MapObjects = new List<IMapObject>();
        }
    }
}
