namespace Shooter.Classes
{
    public class Map
    {
        public int Width{ get; }
        public int Height { get; }
        public ITile[,] Tiles { get; set; }

        public Map()
        {
            Width = 32;
            Height = 32;
            Tiles = new ITile[Width,Height];

            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    Tiles[i, j] = new EmptyTile();
                }
            }
        }
    }
}
