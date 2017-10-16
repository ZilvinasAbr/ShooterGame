using DeenGames.Utils.AStarPathFinder;
using Microsoft.Xna.Framework;
using Shooter.Classes;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
    class PathfindingAdapter : IPathFinding
    {
        private PathFinderFast _adaptee;

        public Point NextPoint(Map map, Point start, Point end)
        {
            int width = map.Width;
            int height = map.Height;

            var grid = new byte[width, height];

            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < height; j++)
                {
                    if (map.Tiles[i, j] is EmptyTile)
                        grid[i, j] = PathFinderHelper.EMPTY_TILE;
                    else
                        grid[i, j] = PathFinderHelper.BLOCKED_TILE;
                }
            }

            _adaptee = new PathFinderFast(grid);

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
