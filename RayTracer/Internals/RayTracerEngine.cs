using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using SDBitmap = System.Drawing.Bitmap;
using PixelFormat= System.Drawing.Imaging.PixelFormat;
using SDRectangle = System.Drawing.Rectangle;
using SDColor = System.Drawing.Color;
using ImageLockMode = System.Drawing.Imaging.ImageLockMode;
using System.Threading;

namespace RayTracer.Internals {
    public delegate void UpdateStatusDelegate(string status);

    public class RayTracerEngine {
        private int screenWidth;
        private int screenHeight;
        private const int MaxDepth = 5;

        public Action<int, int, SDColor> setPixel;

        public RayTracerEngine(int screenWidth, int screenHeight) {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
        }

        private IEnumerable<ISect> Intersections(Ray ray, Scene scene) {
            List<ISect> ret = new List<ISect>();
            // loop over every thing in the scene
            foreach (SceneObject t in scene.Things) {
                // see if the thing intersects with the ray
                ISect intersect = t.Intersect(ray);
                // if it does...
                if (intersect != null) { 
                    // ... add it to our list (ordered by distance, ascending)
                    bool added = false;
                    for (int i = 0; i < ret.Count; i++) {
                        if (ret[i].Dist > intersect.Dist) {
                            ret.Insert(i, intersect);
                            added = true;
                            break;
                        }
                    }
                    if (!added) {
                        // add as last element in the list
                        ret.Add(intersect);
                    }
                }
            }
            return ret;
        }

        private double TestRay(Ray ray, Scene scene) {
            IEnumerable<ISect> isects = Intersections(ray, scene);
            ISect isect = isects.FirstOrDefault();
            if (isect == null)
                return 0;
            return isect.Dist;
        }

        private Color TraceRay(Ray ray, Scene scene, int depth) {
            IEnumerable<ISect> isects = Intersections(ray, scene);
            ISect isect = isects.FirstOrDefault();
            if (isect == null)
                return Color.Background;
            return Shade(isect, scene, depth);
        }

        private Color GetNaturalColor(SceneObject thing, Vector pos, Vector norm, Vector rd, Scene scene) {
            Color ret = Color.Make(0, 0, 0);
            foreach (Light light in scene.Lights) {
                Vector ldis = Vector.Minus(light.Pos, pos);
                Vector livec = Vector.Norm(ldis);
                double neatIsect = TestRay(new Ray() { Start = pos, Dir = livec }, scene);
                bool isInShadow = !((neatIsect > Vector.Mag(ldis)) || (neatIsect == 0));
                if (!isInShadow) {
                    double illum = Vector.Dot(livec, norm);
                    Color lcolor = illum > 0 ? Color.Times(illum, light.Color) : Color.Make(0, 0, 0);
                    double specular = Vector.Dot(livec, Vector.Norm(rd));
                    Color scolor = specular > 0 ? Color.Times(Math.Pow(specular, thing.Surface.Roughness), light.Color) : Color.Make(0, 0, 0);
                    ret = Color.Plus(ret, Color.Plus(Color.Times(thing.Surface.Diffuse(pos), lcolor),
                                                     Color.Times(thing.Surface.Specular(pos), scolor)));
                }
            }
            return ret;
        }

        private Color GetReflectionColor(SceneObject thing, Vector pos, Vector norm, Vector rd, Scene scene, int depth) {
            return Color.Times(thing.Surface.Reflect(pos), TraceRay(new Ray() { Start = pos, Dir = rd }, scene, depth + 1));
        }

        private Color Shade(ISect isect, Scene scene, int depth) {
            Vector d = isect.Ray.Dir;
            Vector pos = Vector.Plus(Vector.Times(isect.Dist, isect.Ray.Dir), isect.Ray.Start);
            Vector normal = isect.Thing.Normal(pos);
            Vector reflectDir = Vector.Minus(d, Vector.Times(2 * Vector.Dot(normal, d), normal));
            Color ret = Color.DefaultColor;
            ret = Color.Plus(ret, GetNaturalColor(isect.Thing, pos, normal, reflectDir, scene));
            if (depth >= MaxDepth) {
                return Color.Plus(ret, Color.Make(.5, .5, .5));
            }
            return Color.Plus(ret, GetReflectionColor(isect.Thing, Vector.Plus(pos, Vector.Times(.001, reflectDir)), normal, reflectDir, scene, depth));
        }

        private double RecenterX(double x) {
            return (x - (screenWidth / 2.0)) / (2.0 * screenWidth);
        }
        private double RecenterY(double y) {
            return -(y - (screenHeight / 2.0)) / (2.0 * screenHeight);
        }

        private Vector GetPoint(double x, double y, Camera camera) {
            return Vector.Norm(Vector.Plus(camera.Forward, Vector.Plus(Vector.Times(RecenterX(x), camera.Right),
                                                                       Vector.Times(RecenterY(y), camera.Up))));
        }

        public SDBitmap Render(Scene scene) {
            SDBitmap bitmap = new SDBitmap(this.screenWidth, this.screenHeight, PixelFormat.Format32bppArgb);
            for (int y = 0; y < screenHeight; y++) {
               for (int x = 0; x < screenWidth; x++) {
                   Color color = TraceRay(new Ray() { Start = scene.Camera.Pos, Dir = GetPoint(x, y, scene.Camera) }, scene, 0);
                   bitmap.SetPixel(x, y, color.ToDrawingColor());
               }
            } 
            return bitmap;
        }
    }
}
