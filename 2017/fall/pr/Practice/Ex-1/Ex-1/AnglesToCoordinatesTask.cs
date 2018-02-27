using System;
using System.Drawing;
using System.IO;
using NUnit.Framework;

namespace Manipulation
{
    public static class AnglesToCoordinatesTask
    {
        /// <summary>
        /// По значению углов суставов возвращает массив координат суставов
        /// в порядке new []{elbow, wrist, palmEnd}
        /// </summary>
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            PointF[] coordinates = new PointF[3];
            double angle = shoulder;
            CalcCoords(coordinates, Manipulator.UpperArm, angle, 0);
            angle -= Math.PI - elbow;
            CalcCoords(coordinates, Manipulator.Forearm, angle, 1);
            angle -= Math.PI - wrist;
            CalcCoords(coordinates, Manipulator.Palm, angle, 2);
            DirectoryInfo a = new DirectoryInfo(".");
            FileInfo b = new FileInfo(".");

            return coordinates;
        }

        private static void CalcCoords(PointF[] coordinates, float jointLength, double angle, int joint)
        {
            coordinates[joint].Y = (float)(Math.Sin(angle) * jointLength);
            coordinates[joint].X = (float)(Math.Sin(Math.PI / 2 - angle) * jointLength);

            if (joint > 0)
            {
                coordinates[joint].X += coordinates[joint - 1].X;
                coordinates[joint].Y += coordinates[joint - 1].Y;
            }
        }
    }
    [TestFixture]
    public class AnglesToCoordinatesTask_Tests
    {
        // Доработайте эти тесты!
        // С помощью строчки TestCase можно добавлять новые тестовые данные. Аргументы TestCase превратятся в аргументы метода.
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI, Manipulator.Forearm + Manipulator.Palm, Manipulator.UpperArm)]
        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            Assert.AreEqual(palmEndX, joints[2].X, 1e-5, "palm endX");
            Assert.AreEqual(palmEndY, joints[2].Y, 1e-5, "palm endY");
        }
    }

}
