using System;
using System.Collections.Generic;

namespace func_rocket
{
    public class LevelsTask
    {
        static readonly Physics standardPhysics = new Physics();
        static readonly Vector target = new Vector(600, 200);
        static readonly Vector location = new Vector(200, 500);

        public static IEnumerable<Level> CreateLevels()
        {
            yield return GetLevel("Zero", target, (size, v) => Vector.Zero);

            yield return GetLevel("Heavy", target, (size, v) => new Vector(0, 0.9));

            yield return GetLevel("Up", new Vector(700, 500), (size, v) => 
            new Vector(0, -300 / (size.Height - v.Y + 300.0)));

            yield return GetLevel("WhiteHole", target, (size, v) => GetWhiteHoleGravity(v));

            yield return GetLevel("BlackHole", target, (size, v) => GetBlackHoleGravity(v));

            yield return GetLevel("BlackAndWhite", target, (size, v) => GetBlackAndWhiteGravity(v));
        }

        private static Vector GetBlackAndWhiteGravity(Vector v)
        {
            Vector vec1 = v - target;
            double angle1 = vec1.Angle;
            double dVecLength1 = vec1.Length;
            double len1 = 140 * dVecLength1 / (dVecLength1 * dVecLength1 + 1);

            Vector vec2 = (location + target) / 2 - v;
            double angle2 = vec2.Angle;
            double dVecLength2 = vec2.Length;
            double len2 = 300 * dVecLength2 / (dVecLength2 * dVecLength2 + 1);

            return new Vector
                (
                (Math.Cos(angle1) * len1 + Math.Cos(angle2) * len2) / 2,
                (Math.Sin(angle1) * len1 + Math.Sin(angle2) * len2) / 2
                );
        }

        private static Vector GetBlackHoleGravity(Vector v)
        {
            Vector vec = (location + target) / 2 - v;
            double angle = vec.Angle;
            double dVecLength = vec.Length;
            double len = 300 * dVecLength / (dVecLength * dVecLength + 1);
            return new Vector
                (
                Math.Cos(angle) * len,
                Math.Sin(angle) * len
                );
        }

        private static Vector GetWhiteHoleGravity(Vector v)
        {
            double angle = (v - target).Angle;
            double dVecLength = (v - target).Length;
            double len = 140 * dVecLength / (dVecLength * dVecLength + 1);
            return new Vector
                (
                Math.Cos(angle) * len,
                Math.Sin(angle) * len
                );
        }

        private static Level GetLevel(string name, Vector target, Gravity gravity)
        {
            return new Level(
                name,
                new Rocket(location, Vector.Zero, -0.5 * Math.PI),
                target,
                gravity, standardPhysics);
        }
    }
}
