using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer.Internals {
    public class Plane : SceneObject {
        public Plane(XmlNode xml) {
            this.Norm = new Vector(xml.Attributes["norm"].Value);
            this.Offset = double.Parse(xml.Attributes["offset"].Value, new CultureInfo("en-US"));
            this.Surface = Surfaces.FindSurface(xml.Attributes["surface"].Value);
        }
        
        public Vector Norm;
        public double Offset;

        public override ISect Intersect(Ray ray) {
            double denom = Vector.Dot(Norm, ray.Dir);
            if (denom > 0) return null;
            return new ISect() {
                Thing = this,
                Ray = ray,
                Dist = (Vector.Dot(Norm, ray.Start) + Offset) / (-denom)
            };
        }

        public override Vector Normal(Vector pos) {
            return Norm;
        }
    }
}
