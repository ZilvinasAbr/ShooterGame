using DeenGames.Utils.AStarPathFinder;
using Microsoft.Xna.Framework;
using Shooter.Classes;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
    class PathFindingAdapter : IPathFinding
    {
        private readonly PathFinderFast _adaptee;
        private readonly byte[,] _grid;

        public PathFindingAdapter(int width, int height)
        {
            _grid = new byte[width,height];
            _adaptee = new PathFinderFast(_grid);
        }

        public Point NextPoint(Map map, Point start, Point end)
        {
            var width = map.Width;
            var height = map.Height;

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (map.Tiles[i, j] is EmptyTile)
                        _grid[i, j] = PathFinderHelper.EMPTY_TILE;
                    else
                        _grid[i, j] = PathFinderHelper.BLOCKED_TILE;
                }
            }

            var path = _adaptee.FindPath(new DeenGames.Utils.Point(start.X, start.Y), new DeenGames.Utils.Point(end.X, end.Y));

            if (path == null)
            {
                return Point.Zero;
            }

            var index = path.Count - 2;

            return new Point(path[index].X, path[index].Y);
        }
    }
}
