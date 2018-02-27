using System;

namespace GeometryTasks
{
    public class Vector
    {
        public double X, Y;
        public double GetLength()
        {
            return Geometry.GetLength(this);
        }
        public Vector Add(Vector vector)
        {
            return Geometry.Add(this, vector);
        }
        public bool Belongs(Segment segment)
        {
            return Geometry.IsVectorInSegment(this, segment);
        }
    }

    public static class Geometry
    {
        public static double GetLength(Vector a)
        {
            return Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        public static double GetLength(Segment segment)
        {
            Vector result = new Vector
            {
                X = segment.End.X - segment.Begin.X,
                Y = segment.End.Y - segment.Begin.Y
            };
            return Math.Sqrt(result.X * result.X + result.Y * result.Y);
        }

        public static Vector Add(Vector a, Vector b)
        {
            return new Vector { X = a.X + b.X, Y = a.Y + b.Y };
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            double Epsilon = 1e-9; 
            bool a = Math.Abs(
                segment.End.X - segment.Begin.X) * (vector.Y - segment.Begin.Y) -
                (segment.End.Y - segment.Begin.Y) * (vector.X - segment.Begin.X) < Epsilon;

            bool b = vector.X >= Math.Min(segment.Begin.X, segment.End.X) &&
                vector.X <= Math.Max(segment.Begin.X, segment.End.X);
            bool c = vector.Y >= Math.Min(segment.Begin.Y, segment.End.Y) &&
                vector.Y <= Math.Max(segment.Begin.Y, segment.End.Y);

            return a && b && c;
        }
    }

    public class Segment
    {
        public Vector Begin, End;
        public double GetLength()
        {
            return Geometry.GetLength(this);
        }

        public  bool Contains(Vector vector)
        {
            return Geometry.IsVectorInSegment(vector, this);
        }
    }
}
