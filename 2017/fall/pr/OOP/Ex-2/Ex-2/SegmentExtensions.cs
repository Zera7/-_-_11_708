using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GeometryTasks;

namespace GeometryPainting
{
    public static class Extension
    {
        public static Dictionary<Segment, Color> Colors = new Dictionary<Segment, Color>();

        public static void SetColor(this Segment segment, Color color)
        {
            if (Colors.ContainsKey(segment))
                Colors[segment] = color;
            else
                Colors.Add(segment, color);
        }

        public static Color GetColor(this Segment segment)
        {
            if (Colors.ContainsKey(segment)) return Colors[segment];
            else return Color.Black;
        }
    }
}
