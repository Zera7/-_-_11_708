using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace Bombermans
{
    static class Graphics
    {
        public static void Test()
        {
            var window = new RenderWindow(new VideoMode(1000, 600), "hi");

            window.Closed += (sender, arg) => window.Close();

            var shape = new CircleShape()
            {
                Radius = 100,
                FillColor = Color.Cyan
            };

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear();
                window.Draw(shape);
                window.Display();
            }
        }
    }
}
