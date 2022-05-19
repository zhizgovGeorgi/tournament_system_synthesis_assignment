using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentDesktopApplication
{
    public static class ThemeColour
    {
        public static Color PrimaryColour { get; set; }
        public static Color SecondaryColour { get; set; }

        public static List<string> ColourList = new List<string>()
        {
            "#3F51B5",
            "#009688",
            "#FF5722",
            "#607D8B",
            "#EA676C",
            "#126881",
            "#018790",
        };

        public static Color ChangeColourBrightness(Color colour, double correctionFactor)
        {
            double red = colour.R;
            double green = colour.G;
            double blue = colour.B;

            // if less than 0, darken colour
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }

            //if greater than 0, lighten colour
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(colour.A, (byte)red, (byte)green, (byte)green);
        }
    }
}
