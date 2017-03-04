namespace Creatures
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelRender = new System.Windows.Forms.Panel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.simulationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStatus = new System.Windows.Forms.StatusStrip();
            this.LabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu.SuspendLayout();
            this.MenuStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelRender
            // 
            this.PanelRender.BackColor = System.Drawing.Color.Black;
            this.PanelRender.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRender.Location = new System.Drawing.Point(0, 24);
            this.PanelRender.Name = "PanelRender";
            this.PanelRender.Size = new System.Drawing.Size(728, 696);
            this.PanelRender.TabIndex = 0;
            this.PanelRender.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelRender_MouseClick);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simulationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.fullscreenToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(728, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // simulationToolStripMenuItem
            // 
            this.simulationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseStartToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.simulationToolStripMenuItem.Name = "simulationToolStripMenuItem";
            this.simulationToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.simulationToolStripMenuItem.Text = "Simulation";
            // 
            // pauseStartToolStripMenuItem
            // 
            this.pauseStartToolStripMenuItem.Name = "pauseStartToolStripMenuItem";
            this.pauseStartToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pauseStartToolStripMenuItem.Text = "Pause/Play [F2]";
            this.pauseStartToolStripMenuItem.Click += new System.EventHandler(this.pauseStartToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.settingsToolStripMenuItem.Text = "Settings [F3]";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // fullscreenToolStripMenuItem
            // 
            this.fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
            this.fullscreenToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.fullscreenToolStripMenuItem.Text = "Fullscreen [F4]/[ESC]";
            this.fullscreenToolStripMenuItem.Click += new System.EventHandler(this.fullscreenToolStripMenuItem_Click);
            // 
            // MenuStatus
            // 
            this.MenuStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelStatus,
            this.LabelStatus2});
            this.MenuStatus.Location = new System.Drawing.Point(0, 720);
            this.MenuStatus.Name = "MenuStatus";
            this.MenuStatus.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MenuStatus.Size = new System.Drawing.Size(728, 22);
            this.MenuStatus.TabIndex = 2;
            this.MenuStatus.Text = "statusStrip1";
            // 
            // LabelStatus
            // 
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // LabelStatus2
            // 
            this.LabelStatus2.Name = "LabelStatus2";
            this.LabelStatus2.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 742);
            this.Controls.Add(this.PanelRender);
            this.Controls.Add(this.MenuStatus);
            this.Controls.Add(this.MainMenu);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creatures";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MenuStatus.ResumeLayout(false);
            this.MenuStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelRender;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem simulationToolStripMenuItem;
        private System.Windows.Forms.StatusStrip MenuStatus;
        private System.Windows.Forms.ToolStripStatusLabel LabelStatus;
        private System.Windows.Forms.ToolStripMenuItem pauseStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullscreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel LabelStatus2;
    }
}