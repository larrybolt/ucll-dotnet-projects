﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Internals {
    public class Color {
        public double R;
        public double G;
        public double B;

        public Color(double r, double g, double b) { R = r; G = g; B = b; }
        public Color(string str) {
            string[] nums = str.Split(',');
            if (nums.Length != 3) throw new ArgumentException();
            CultureInfo formatProvider = new CultureInfo("en-US");
            R = double.Parse(nums[0], formatProvider);
            G = double.Parse(nums[1], formatProvider);
            B = double.Parse(nums[2], formatProvider);
        }

        public static Color Make(double r, double g, double b) { return new Color(r, g, b); }

        public static Color Times(double n, Color v) {
            return new Color(n * v.R, n * v.G, n * v.B);
        }
        public static Color Times(Color v1, Color v2) {
            return new Color(v1.R * v2.R, v1.G * v2.G, v1.B * v2.B);
        }

        public static Color Plus(Color v1, Color v2) {
            return new Color(v1.R + v2.R, v1.G + v2.G, v1.B + v2.B);
        }
        public static Color Minus(Color v1, Color v2) {
            return new Color(v1.R - v2.R, v1.G - v2.G, v1.B - v2.B);
        }

        public static readonly Color Background = Make(0, 0, 0);
        public static readonly Color DefaultColor = Make(0, 0, 0);

        private static double Legalize(double d) {
            return d > 1 ? 1 : d;
        }

        internal System.Drawing.Color ToDrawingColor() {
            return System.Drawing.Color.FromArgb((int)(Legalize(R) * 255), (int)(Legalize(G) * 255), (int)(Legalize(B) * 255));
        }

    }
}
