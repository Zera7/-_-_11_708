using System;

namespace func_rocket
{
    public class ControlTask
    {
        public static Turn ControlRocket(Rocket rocket, Vector target)
        {
            Vector vRocketToTarget = rocket.Location - target;
            Vector vDirection = new Vector(1, 0).Rotate(rocket.Direction);
            Vector vMove = (vDirection + rocket.Velocity.Normalize());
            double angleMoveToTarget = GetDifferenceAngle(vMove, vRocketToTarget);

            if (angleMoveToTarget <= 0.01) return Turn.None;

            Vector vRight = vMove.Rotate(angleMoveToTarget / 2);
            Vector vLeft = vMove.Rotate(-angleMoveToTarget / 2);
            double angleRight = GetDifferenceAngle(vRight, vRocketToTarget);
            double angleLeft = GetDifferenceAngle(vLeft, vRocketToTarget);

            return angleRight < angleLeft ? Turn.Left : Turn.Right;
        }

        /// <summary>
        /// Находит угол между векторами
        /// </summary>
        /// <param name="v1">Вектор 1</param>
        /// <param name="v2">Вектор 2</param>
        /// <returns></returns>
        public static double GetDifferenceAngle(Vector v1, Vector v2)
        {
            return Math.Acos((v1.X * v2.X + v1.Y * v2.Y) / (v1.Length * v2.Length));
        }
    }
}