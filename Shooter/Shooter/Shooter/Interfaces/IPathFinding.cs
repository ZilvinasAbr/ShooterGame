using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Shooter.Classes;
using Shooter.Enums;

namespace Shooter.Interfaces
{
    public interface IPathFinding
    {
        Point NextPoint(IEnumerable<IMapObject> mapObjects, Point start, Point end);
    }
}
