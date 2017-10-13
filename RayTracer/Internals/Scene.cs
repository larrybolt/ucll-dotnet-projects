using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer.Internals {
    public class Scene {
        public Scene(string name) {
            this.Things = new List<SceneObject>();
            this.Lights = new List<Light>();
            this.Name = name;
        }

        public List<SceneObject> Things;
        public List<Light> Lights;
        public Camera Camera;
        public string Name;

        public IEnumerable<ISect> Intersect(Ray r) {
            return from thing in Things
                   select thing.Intersect(r);
        }

        public static object Scenes {
            get { 
                //
                return null;
            }
        }
    }
}
