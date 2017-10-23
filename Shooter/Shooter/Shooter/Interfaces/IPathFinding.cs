using Microsoft.Xna.Framework;

namespace Shooter.Interfaces
{
    public interface IPathFinding
    {
        Point NextPoint(Point start, Point end);
    }
}
