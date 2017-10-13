using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer.Internals {
    public abstract class SceneObject {
        public Surface Surface;
        public abstract ISect Intersect(Ray ray);
        public abstract Vector Normal(Vector pos);

        public static SceneObject Create(XmlNode xml) {
            if (xml.Name == "Plane") {
                return new Plane(xml);
            } else if (xml.Name == "Sphere") {
                return new Sphere(xml);
            } else {
                throw new ArgumentException("Wrong type of scene object!");
            }
        }
    }
}
