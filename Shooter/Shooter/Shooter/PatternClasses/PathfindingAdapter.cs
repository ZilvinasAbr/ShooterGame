using DeenGames.Utils.AStarPathFinder;
using Microsoft.Xna.Framework;
using Shooter.Classes;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
    class PathFindingAdapter : IPathFinding
    {
        private readonly Map _map;
        private readonly PathFinderFast _adaptee;
        private readonly byte[,] _grid;
        
        public PathFindingAdapter(Map map)
        {
            _map = map;
            _grid = new byte[_map.Width,_map.Height];
            _adaptee = new PathFinderFast(_grid);
        }

        public Point NextPoint(Point start, Point end)
        {
            if (start == end)
            {
                return start;
            }

            var width = _map.Width;
            var height = _map.Height;

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    _grid[i, j] = PathFinderHelper.EMPTY_TILE;
                }
            }

            foreach (var mapObject in _map.MapObjects)
            {
                if (mapObject is Enemy || mapObject is Wall)
                {
                    var mapObjectX = (int)mapObject.Position.X / GameSettings.TileSize;
                    var mapObjectY = (int)mapObject.Position.Y / GameSettings.TileSize;
                    _grid[mapObjectX, mapObjectY] = PathFinderHelper.BLOCKED_TILE;
                }
            }

            var normalizedStart = new DeenGames.Utils.Point(start.X / GameSettings.TileSize, start.Y / GameSettings.TileSize);
            var normalizedEnd = new DeenGames.Utils.Point(end.X / GameSettings.TileSize, end.Y / GameSettings.TileSize);

            var path = _adaptee.FindPath(normalizedStart, normalizedEnd);

            if (path == null || path.Count <= 1)
            {
                return start;
            }

            var index = path.Count - 2;

            return new Point(path[index].X * GameSettings.TileSize, path[index].Y * GameSettings.TileSize);
        }
    }
}
