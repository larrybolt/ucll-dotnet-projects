using System.Drawing;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace RayTracer {    
    public class Program {
        // Original code from Luke Hoban's Blog
        [STAThread]
        public static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
    }
}
