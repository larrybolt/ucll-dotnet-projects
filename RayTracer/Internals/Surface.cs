using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Internals {
    public class Surface {
        public Func<Vector, Color> Diffuse;
        public Func<Vector, Color> Specular;
        public Func<Vector, double> Reflect;
        public double Roughness;
    }
}
