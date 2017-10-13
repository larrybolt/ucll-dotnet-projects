using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RayTracer.Internals {
    public class SceneList : IEnumerable {
        public SceneList() {
            _scenes = new List<Scene>();

            XmlDocument doc = new XmlDocument();
            doc.Load("Scenes.xml");

            foreach (XmlNode scene in doc.SelectNodes("/Scenes/Scene")) {
                Scene s = new Scene(scene.Attributes["name"].Value);
                foreach (XmlNode thing in scene.SelectNodes("./Things/*")) {
                    s.Things.Add(SceneObject.Create(thing));
                }
                foreach (XmlNode light in scene.SelectNodes("./Lights/*")) {
                    s.Lights.Add(new Light(light));
                }
                XmlNode camNode = scene.SelectSingleNode("./Camera");
                s.Camera = Camera.Create(new Vector(camNode.Attributes["pos"].Value), new Vector(camNode.Attributes["lookAt"].Value));
                _scenes.Add(s);
            }
        }


        public Scene GetByName(string name) {
            foreach (Scene s in _scenes) {
                if (s.Name == name)
                    return s;
            }
            return null;
        }

        public IEnumerator GetEnumerator() {
            return new SceneListEnumerator(_scenes);
        }

        private class SceneListEnumerator : IEnumerator {
            public SceneListEnumerator(List<Scene> sl) {
                _index = -1;
                _sceneList = sl;
            }

            public bool MoveNext() {
                int i = _index + 1;
                if (i >= _sceneList.Count)
                    return false;
                _index = i;
                return true;
            }

            public object Current {
                get {
                    if (_index < 0)
                        throw new NotSupportedException();
                    return _sceneList[_index];
                }
            }

            public void Reset() {
                _index = -1;
            }

            private int _index;
            private List<Scene> _sceneList;
        }

        private List<Scene> _scenes;
    }
}
