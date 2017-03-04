using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;


namespace Creatures
{
    public partial class SettingsForm : Form
    {

        #region StartupAndMeta

        //Defines the settings form
        public SettingsForm()
        {
            InitializeComponent();

            //Read and Apply current settings
            CBrfov.Checked = Program.game.currentSettings.RenderFieldsOfView;
            CBrci.Checked = Program.game.currentSettings.RenderCreatureInformation;
            CBmusic.Checked = Program.game.currentSettings.PlayMusic;
            AmountC.Value = Program.game.currentSettings.CreatureAmount;
            AmountG.Value = Program.game.currentSettings.NewGenerationAt;
            AmountF.Value = Program.game.currentSettings.FoodAmount;
            AmountP.Value = Program.game.currentSettings.PoisonAmount;
            AmountM.Value = Program.game.currentSettings.Mutation;
            SpeedBar.Value = Program.game.currentSettings.SimulationSpeed;
        }

        //Saves the settings
        private void Save()
        {
            Program.game.currentSettings.CreatureAmount = (int)AmountC.Value;
            Program.game.currentSettings.FoodAmount = (int)AmountF.Value;
            Program.game.currentSettings.PoisonAmount = (int)AmountP.Value;
            Program.game.currentSettings.NewGenerationAt = (int)AmountG.Value;
            Program.game.currentSettings.Mutation = (int)AmountM.Value;
            Program.game.currentSettings.PlayMusic = CBmusic.Checked;
            Program.game.currentSettings.RenderFieldsOfView = CBrfov.Checked;
            Program.game.currentSettings.RenderCreatureInformation = CBrci.Checked;
            Program.game.currentSettings.SimulationSpeed = SpeedBar.Value;
        }

        #endregion

        #region UIHandlers

        //Ok button clicked
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            //Apply settings
            Renderers.CreatureRenderer.renderFOV = CBrfov.Checked;
            Program.game.renderText = CBrci.Checked;
            if (!(Program.game.musicInstance.State == Microsoft.Xna.Framework.Audio.SoundState.Playing))
            {
                if (CBmusic.Checked) Program.game.musicInstance.Play();
            }
            else
            {
                if (!CBmusic.Checked) Program.game.musicInstance.Stop();
            }
            Program.game.simulationSpeed = (float)SpeedBar.Value;

            //Save settings
            Save();
            this.Close();
        }

        //Abort button clicked
        private void ButtonAbort_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Start a new simulation button clicked
        private void ButtonStart_Click(object sender, EventArgs e)
        {   
            
            //Apply settings
            Managers.CreatureManager.maximumObjects = (int)AmountC.Value;  
            Managers.CreatureManager.newGenerationAt = (int)AmountG.Value;
            Managers.CreatureManager.mutation = (float)(AmountM.Value / 100);
            Managers.FoodManager.maximumObjects = (int)AmountF.Value;
            Managers.PoisonManager.maximumObjects = (int)AmountP.Value;

            //Clear objects
            Managers.CreatureManager.creatures.Clear();  
            Managers.FoodManager.foods.Clear();
            Managers.PoisonManager.poisons.Clear();

            //Spawn new objects
            for (int i = 0; i < Managers.CreatureManager.maximumObjects; i++) Managers.CreatureManager.InsertRandom(new Microsoft.Xna.Framework.Rectangle(0, 0, Program.game.graphics.PreferredBackBufferWidth, Program.game.graphics.PreferredBackBufferHeight));
            for (int i = 0; i < Managers.FoodManager.maximumObjects; i++) Managers.FoodManager.InsertRandom(new Microsoft.Xna.Framework.Rectangle(0, 0, Program.game.graphics.PreferredBackBufferWidth, Program.game.graphics.PreferredBackBufferHeight));
            for (int i = 0; i < Managers.PoisonManager.maximumObjects; i++) Managers.PoisonManager.InsertRandom(new Microsoft.Xna.Framework.Rectangle(0, 0, Program.game.graphics.PreferredBackBufferWidth, Program.game.graphics.PreferredBackBufferHeight));
           
            //Set gereation to 1
            Program.game.generationCount = 1;

            //Save settings
            Save();
            this.Close();
        }

        #endregion

    }
}
