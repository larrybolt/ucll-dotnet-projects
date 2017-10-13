using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2_windowsforms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            wordToolStripMenuItem.Checked = textBox1.WordWrap;
            wordToolStripMenuItem.Click += WordToolStripMenuItem_CheckedChanged;
        }

        private void WordToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            bool newStatus = !wordToolStripMenuItem.Checked;
            textBox1.WordWrap = newStatus;
            wordToolStripMenuItem.Checked = newStatus;
        }
    }
}
