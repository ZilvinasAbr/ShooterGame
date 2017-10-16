using Microsoft.Xna.Framework;
using Shooter.Classes;
using Shooter.Enums;

namespace Shooter.Interfaces
{
    public interface IPathFinding
    {
        Point NextPoint(Map map, Point start, Point end);
    }
}
