﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Classes;
using Shooter.Enums;
using Shooter.Interfaces;

namespace Shooter.PatternClasses
{
    public class EnemiesConcreteFactory : EnemiesFactory
    {
        public override Enemy CreateEnemy(IPathFinding pathFinder, EnemyType type, IWeapon weapon, IPlayer player, double lifePoints, Vector2 position, Texture2D texture, IActionState state)
        {
            switch (type)
            {
                case EnemyType.Small:
                    return new EnemyA(pathFinder, weapon, player, lifePoints, position, texture, state);
                case EnemyType.Big:
                    return new EnemyB(pathFinder, weapon, player, lifePoints, position, texture, state);
                case EnemyType.Boss:
                    return new Boss(pathFinder, weapon, player, lifePoints, position, texture, state);
                default:
                    return null;
            }
        }
    }
}