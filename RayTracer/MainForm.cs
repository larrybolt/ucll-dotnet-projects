using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RayTracer.Internals;

namespace RayTracer {
    public partial class MainForm : Form {
        public MainForm() {
            _scenes = new SceneList();
            InitializeComponent();
            this.MinimumSize = new Size(RenderedImage.Width, RenderedImage.Height);
            foreach(Scene s in _scenes) {
                ToolStripMenuItem mi = new ToolStripMenuItem { Text = s.Name };
                mi.Click += this.OnSceneClick;
                this.SceneMenu.DropDownItems.Add(mi);
            }
            ToolStripMenuItem first = SceneMenu.DropDownItems[0] as ToolStripMenuItem;
            first.Checked = true;
            _selectedScene = first.Text;
        }

        private void OnSceneClick(object sender, EventArgs e) {
            foreach (ToolStripMenuItem item in SceneMenu.DropDownItems) {
                item.Checked = (sender == item);
                if (item.Checked) {
                    _selectedScene = item.Text;
                }
            }
        }
                
        private void MainForm_Resize(object sender, EventArgs e) {
            CenterRenderedImage();
        }
        
        private void RenderMenu_Click(object sender, EventArgs e) {
            // disable the render menu while rendering
            RenderMenu.Enabled = false;
            // find the render size (stored as an object in the selected menu's Tag property)
            int size = int.Parse((sender as ToolStripMenuItem).Tag.ToString());
            // create a new Bitmap object where we will render to
            _bitmap = new Bitmap(size, size);
            // update the size and location of the picturebox that will show the final result
            RenderedImage.Size = new Size(size, size);
            RenderedImage.BackgroundImage = null;
            CenterRenderedImage();
            // print out a message on the picture box
            using (Graphics g = RenderedImage.CreateGraphics()) {
                g.FillRectangle(SystemBrushes.Control, 0, 0, RenderedImage.Width, RenderedImage.Height);
                g.DrawString("Rendering.\r\nPlease wait...", this.Font, SystemBrushes.WindowText, 0f, 0f);
            }
            // create the ray tracer
            RayTracerEngine rayTracer = new RayTracerEngine(_bitmap.Width, _bitmap.Height);
            // start rendering the scene
            RenderedImage.BackgroundImage = rayTracer.Render(_scenes.GetByName(_selectedScene));
            // re-enable the render menu
            RenderMenu.Enabled = true;
        }

        private void rayTracer_OnUpdateStatus(string status) {
            if (this.InvokeRequired) {
                this.Invoke(new UpdateStatusDelegate(rayTracer_OnUpdateStatus), status);
            } else {
                StatusText.Text = status;
            }
        }

        private void ExitMenu_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void CenterRenderedImage() {
            RenderedImage.Location = new Point() { X = (this.ClientSize.Width - RenderedImage.Width) / 2, Y = MenuBar.Height + (this.ClientSize.Height - RenderedImage.Height - MenuBar.Height - StatusBar.Height) / 2 };
        }
        
        private Bitmap _bitmap;
        private SceneList _scenes;
        private string _selectedScene;
    }
}
