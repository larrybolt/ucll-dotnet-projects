using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer.Internals {
    public class Camera {
        public Vector Pos;
        public Vector Forward;
        public Vector Up;
        public Vector Right;

        public static Camera Create(Vector pos, Vector lookAt) {
            Vector forward = Vector.Norm(Vector.Minus(lookAt, pos));
            Vector down = new Vector(0, -1, 0);
            Vector right = Vector.Times(1.5, Vector.Norm(Vector.Cross(forward, down)));
            Vector up = Vector.Times(1.5, Vector.Norm(Vector.Cross(forward, right)));

            Camera createdCamera = new Camera();
            createdCamera.Pos = pos;
            createdCamera.Forward = forward;
            createdCamera.Up = up;
            createdCamera.Right = right;
            return createdCamera;
        }
    }
}
