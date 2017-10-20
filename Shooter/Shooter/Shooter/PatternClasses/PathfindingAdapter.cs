using System.Collections.Generic;
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
        private readonly int _width;
        private readonly int _height;

        public PathFindingAdapter(int width, int height)
        {
            _width = width;
            _height = height;
            _grid = new byte[width,height];
            _adaptee = new PathFinderFast(_grid);
        }

        public Point NextPoint(IEnumerable<IMapObject> mapObjects, Point start, Point end)
        {
            for (var i = 0; i < _width; i++)
            {
                for (var j = 0; j < _height; j++)
                {
                    _grid[i, j] = PathFinderHelper.EMPTY_TILE;
                }
            }

            foreach (var mapObject in mapObjects)
            {
                _grid[(int) mapObject.Position.X, (int) mapObject.Position.Y] = PathFinderHelper.BLOCKED_TILE;
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
