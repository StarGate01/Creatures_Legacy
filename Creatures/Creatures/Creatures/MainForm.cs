using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Creatures
{
    public partial class MainForm : Form
    {

        #region StartupAndMeta

        //The main form for the windowed mode
        public MainForm()
        {
            InitializeComponent();

            //Update ttitle to current version
            this.Text += " V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            //Set size for small window
            this.Width = 800;
            this.Height = 450 + MenuStatus.Height + MainMenu.Height;
        }

        //Return the render target handle for windowed mode
        public IntPtr getDrawSurface()
        {
            return PanelRender.Handle;
        }

        #endregion

        #region UserInteraction

        //Keydown handler
        private void MainForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (!Program.game.isFullscreen)
            {
                switch (e.KeyCode)
                {
                    //Play/pause
                    case Keys.F2:
                        pauseStartToolStripMenuItem.PerformClick();
                        break;
                    //Settings
                    case Keys.F3:
                        settingsToolStripMenuItem.PerformClick();
                        break;
                    //Fullscreen
                    case Keys.F4:
                        fullscreenToolStripMenuItem.PerformClick();
                        break;
                }
            }
        }

        //Select a creature, forward to Game1 handler
        private void PanelRender_MouseClick(object sender, MouseEventArgs e)
        {
            Program.game.HandleClick(e.X, e.Y);
        }

        #endregion

        #region UIHandlers

        //Play/pause button clicked
        private void pauseStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.game.PlayPause();
        }

        //Exit button clicked
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Settings button clicked
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pause game
            bool wasPaused = Program.game.isPaused;
            Program.game.isPaused = true;

            //Show settigs form
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);

            if (!wasPaused) Program.game.isPaused = false;
        }

        //Fullscreen button clicked
        private void fullscreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.game.EnableFullscreen();
        }

        //About button clicked
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pause game
            bool wasPaused = Program.game.isPaused;
            Program.game.isPaused = true;

            //Show messagebox, update version
            MessageBox.Show("Creatures V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + Environment.NewLine +
                "Devoloped by C. Honal aka StarGate01" + Environment.NewLine +
                "Music 'Clean Soul' by Kevin MacLeod", "Creatures - About", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!wasPaused) Program.game.isPaused = false;
        }

        #endregion

    }
}
