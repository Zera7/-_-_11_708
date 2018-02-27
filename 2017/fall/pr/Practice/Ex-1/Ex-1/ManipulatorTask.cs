using System;
using NUnit.Framework;

namespace Manipulation
{
    public static class ManipulatorTask
    {

        public struct DPoint
        {
            public double X;
            public double Y;

            public DPoint(double x, double y)
            {
                X = x;
                Y = y;
            }
            public double GetLengthLine()
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        /// <summary>
        /// Возвращает массив углов (shoulder, elbow, wrist),
        /// необходимых для приведения эффектора манипулятора в точку x и y 
        /// с углом между последним суставом и горизонталью, равному angle (в радианах)
        /// См. чертеж manipulator.png!
        /// </summary>
        public static double[] MoveManipulatorTo(double x, double y, double angle)
        {
            // Используйте поля Forearm, UpperArm, Palm класса Manipulator
            DPoint wristPoint = new DPoint
            {
                X = y + Math.Sin(angle) * Manipulator.Palm,
                Y = x - Math.Sin((Math.PI / 2) - angle) * Manipulator.Palm
            };
            double elbowAngle = TriangleTask.GetABAngle(
                Manipulator.UpperArm,
                Manipulator.Forearm,
                wristPoint.GetLengthLine()
                );
            double shoulderAngle = TriangleTask.GetABAngle(
                wristPoint.GetLengthLine(),
                Manipulator.UpperArm,
                Manipulator.Forearm
                ) + Math.Atan2(wristPoint.X, wristPoint.Y);
            double wristAngle = -angle - shoulderAngle - elbowAngle;

            return new[] { shoulderAngle, elbowAngle, wristAngle };
        }
    }

    [TestFixture]
    public class ManipulatorTask_Tests
    {
        [Test]
        public void TestMoveManipulatorTo()
        {
            Assert.Fail("Write real tests here!");
        }
    }
}