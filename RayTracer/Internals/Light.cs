using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer.Internals {
    public class Light {
        public Light(XmlNode xml) {
            this.Pos = new Vector(xml.Attributes["pos"].Value);
            this.Color = new Color(xml.Attributes["color"].Value);
        }
        
        public Vector Pos;
        public Color Color;
    }
}
