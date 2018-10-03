using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance.Geometry
{
    public abstract class Body
    {
        public abstract double GetVolume();

        public abstract void Accept(IVisitor visitor);
    }

    public class Ball : Body
    {
        public double Radius { get; set; }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);

        public override double GetVolume() => 4.0 * Math.PI * Math.Pow(Radius, 3) / 3;
    }

    public class Cube : Body
    {
        public double Size { get; set; }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);

        public override double GetVolume() => Math.Pow(Size, 3);
    }

    public class Cyllinder : Body
    {
        public double Height { get; set; }
        public double Radius { get; set; }

        public override void Accept(IVisitor visitor) => visitor.Visit(this);

        public override double GetVolume() => Math.PI * Math.Pow(Radius, 2) * Height;
    }

    public interface IVisitor
    {
        void Visit(Ball obj);
        void Visit(Cube obj);
        void Visit(Cyllinder obj);
    }

    public class SurfaceAreaVisitor : IVisitor
    {
        public double SurfaceArea { get; private set; }

        public void Visit(Ball ball)
        {
            SurfaceArea = 4 * Math.Pow(ball.Radius, 2) * Math.PI;
        }

        public void Visit(Cube cube)
        {
            SurfaceArea = Math.Pow(cube.Size, 2) * 6;
        }

        public void Visit(Cyllinder cyllinder)
        {
            SurfaceArea = 2 * Math.PI * cyllinder.Radius * (cyllinder.Height + cyllinder.Radius);
        }
    }

    public class DimensionsVisitor : IVisitor
    {
        public Dimensions Dimensions { get; private set; }

        public void Visit(Ball ball)
        {
            Dimensions = new Dimensions(ball.Radius * 2, ball.Radius * 2);
        }

        public void Visit(Cube cube)
        {
            Dimensions = new Dimensions(cube.Size, cube.Size);
        }

        public void Visit(Cyllinder cyllinder)
        {
            Dimensions = new Dimensions(cyllinder.Radius * 2, cyllinder.Height);
        }
    }
}
