namespace RayTracer {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RenderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.Render100Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Render250Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.Render500Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.SceneMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.RenderedImage = new System.Windows.Forms.PictureBox();
            this.Render1000Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RenderedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.RenderMenu,
            this.SceneMenu});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(500, 24);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMenu});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // ExitMenu
            // 
            this.ExitMenu.Name = "ExitMenu";
            this.ExitMenu.Size = new System.Drawing.Size(92, 22);
            this.ExitMenu.Text = "Exit";
            this.ExitMenu.Click += new System.EventHandler(this.ExitMenu_Click);
            // 
            // RenderMenu
            // 
            this.RenderMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Render100Menu,
            this.Render250Menu,
            this.Render500Menu,
            this.Render1000Menu});
            this.RenderMenu.Name = "RenderMenu";
            this.RenderMenu.Size = new System.Drawing.Size(56, 20);
            this.RenderMenu.Text = "Render";
            // 
            // Render100Menu
            // 
            this.Render100Menu.Name = "Render100Menu";
            this.Render100Menu.Size = new System.Drawing.Size(152, 22);
            this.Render100Menu.Tag = "100";
            this.Render100Menu.Text = "100 x 100";
            this.Render100Menu.Click += new System.EventHandler(this.RenderMenu_Click);
            // 
            // Render250Menu
            // 
            this.Render250Menu.Name = "Render250Menu";
            this.Render250Menu.Size = new System.Drawing.Size(152, 22);
            this.Render250Menu.Tag = "250";
            this.Render250Menu.Text = "250 x 250";
            this.Render250Menu.Click += new System.EventHandler(this.RenderMenu_Click);
            // 
            // Render500Menu
            // 
            this.Render500Menu.Name = "Render500Menu";
            this.Render500Menu.Size = new System.Drawing.Size(152, 22);
            this.Render500Menu.Tag = "500";
            this.Render500Menu.Text = "500 x 500";
            this.Render500Menu.Click += new System.EventHandler(this.RenderMenu_Click);
            // 
            // Render1000Menu
            // 
            this.Render1000Menu.Name = "Render1000Menu";
            this.Render1000Menu.Size = new System.Drawing.Size(152, 22);
            this.Render1000Menu.Tag = "1000";
            this.Render1000Menu.Text = "1000 x 1000";
            this.Render1000Menu.Click += new System.EventHandler(this.RenderMenu_Click);
            // 
            // SceneMenu
            // 
            this.SceneMenu.Name = "SceneMenu";
            this.SceneMenu.Size = new System.Drawing.Size(50, 20);
            this.SceneMenu.Text = "Scene";
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText});
            this.StatusBar.Location = new System.Drawing.Point(0, 527);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(500, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(0, 17);
            // 
            // RenderedImage
            // 
            this.RenderedImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RenderedImage.Location = new System.Drawing.Point(0, 27);
            this.RenderedImage.Name = "RenderedImage";
            this.RenderedImage.Size = new System.Drawing.Size(500, 500);
            this.RenderedImage.TabIndex = 3;
            this.RenderedImage.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 549);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MenuBar);
            this.Controls.Add(this.RenderedImage);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RenderedImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.PictureBox RenderedImage;
        private System.Windows.Forms.ToolStripMenuItem RenderMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMenu;
        private System.Windows.Forms.ToolStripMenuItem Render100Menu;
        private System.Windows.Forms.ToolStripMenuItem Render250Menu;
        private System.Windows.Forms.ToolStripMenuItem Render500Menu;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.ToolStripMenuItem SceneMenu;
        private System.Windows.Forms.ToolStripMenuItem Render1000Menu;
    }
}