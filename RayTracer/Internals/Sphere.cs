using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer.Internals {
    public class Sphere : SceneObject {
        public Sphere(XmlNode xml) {
            this.Center = new Vector(xml.Attributes["center"].Value);
            this.Radius = double.Parse(xml.Attributes["radius"].Value, new CultureInfo("en-US"));
            this.Surface = Surfaces.FindSurface(xml.Attributes["surface"].Value);
        }

        public Vector Center;
        public double Radius;

        public override ISect Intersect(Ray ray) {
            Vector eo = Vector.Minus(Center, ray.Start);
            double v = Vector.Dot(eo, ray.Dir);
            double dist;
            if (v < 0) {
                dist = 0;
            } else {
                double disc = Math.Pow(Radius, 2) - (Vector.Dot(eo, eo) - Math.Pow(v, 2));
                dist = disc < 0 ? 0 : v - Math.Sqrt(disc);
            }
            if (dist == 0) return null;
            return new ISect() {
                Thing = this,
                Ray = ray,
                Dist = dist
            };
        }

        public override Vector Normal(Vector pos) {
            return Vector.Norm(Vector.Minus(pos, Center));
        }
    }
}
