using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Internals {
    public static class Surfaces {
        public static Surface FindSurface(string name) {
            if (name == "CheckerBoard") {
                return CheckerBoard;
            } else if (name == "Shiny") {
                return Shiny;
            } else if (name == "NonShiny") {
                return NonShiny;
            } else {
                throw new ArgumentException("Wrong surface name!");
            }
        }


        // Only works with X-Z plane.
        public static readonly Surface CheckerBoard =
            new Surface() {
                Diffuse = pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? Color.Make(1, 1, 1)
                                    : Color.Make(0, 0, 0),
                Specular = pos => Color.Make(1, 1, 1),
                Reflect = pos => ((Math.Floor(pos.Z) + Math.Floor(pos.X)) % 2 != 0)
                                    ? .1
                                    : .7,
                Roughness = 150
            };


        public static readonly Surface Shiny =
            new Surface() {
                Diffuse = pos => Color.Make(1, 1, 1),
                Specular = pos => Color.Make(.5, .5, .5),
                Reflect = pos => .6,
                Roughness = 50
            };

        public static readonly Surface NonShiny =
            new Surface() {
                Diffuse = pos => Color.Make(1, 1, 1),
                Specular = pos => Color.Make(.5, .5, .5),
                Reflect = pos => 0,
                Roughness = 50
            };
    }
}
