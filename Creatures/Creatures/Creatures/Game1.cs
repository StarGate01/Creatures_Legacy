using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Creatures
{

    //The main XNA game object
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        #region Attributes

        //Settings
        public Settings.Settings currentSettings;
        public string settingsPath = "settings.xml";

        //Graphics device, font and sound
        public GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SpriteFont normalFont;
        private SoundEffect music;
        public SoundEffectInstance musicInstance;

        //Managing attributes
        public Random rnd;
        public bool isFullscreen;
        public bool isPaused = false;
        public float simulationSpeed = (float)1;
        public bool renderText = true;
        public SimulationObjects.Creature selectedCreature = null;
        public int generationCount = 1;

        //Objects for Windowed mode
        public IntPtr drawSurface;
        private System.Windows.Forms.Form hostForm;
        private System.Windows.Forms.StatusStrip mainMenu;

        #endregion

        #region StartupAndMeta

        //Constructor
        public Game1(IntPtr drawSurface)
        {
            //Setup environment and init graphics
            rnd = new Random(Environment.TickCount);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            //Setup windowed form
            hostForm = System.Windows.Forms.Control.FromHandle(drawSurface).FindForm();
            hostForm.Icon = System.Windows.Forms.Control.FromHandle(this.Window.Handle).FindForm().Icon;
            mainMenu = (System.Windows.Forms.StatusStrip)hostForm.Controls["MenuStatus"];

            //Add event handlers to correctly setup an alternate render target
            System.Windows.Forms.Control.FromHandle(this.Window.Handle).VisibleChanged += new EventHandler(Game1_VisibleChanged);
            hostForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Game1_RequestExit);
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);

            //Test if it worked
            EnableFullscreen();
            DisableFullscreen();
        }

        //Set the render target
        public void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = drawSurface;
        }

        //Hide the XNA window in windowed mode
        public void Game1_VisibleChanged(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible == true)
            {
                if (!Program.game.isFullscreen) System.Windows.Forms.Control.FromHandle((this.Window.Handle)).Visible = false;
            }
        }

        #endregion

        #region InitAndLoad

        //Initializes the Simulation
        protected override void Initialize()
        {
            //Handle settings
            if (!System.IO.File.Exists(settingsPath))
            {
                //Create settings file if not exists
                System.IO.File.Create(settingsPath);
                currentSettings = new Settings.Settings();
                Settings.SettingsManager.Save(currentSettings, settingsPath);
            }
            try
            {
                //Load settings
                currentSettings = Settings.SettingsManager.Load(settingsPath);
            }
            catch
            {
                //On failure, use default settings
                currentSettings = new Settings.Settings();
            }

            //Apply settings
            renderText = currentSettings.RenderCreatureInformation;
            Renderers.CreatureRenderer.renderFOV = currentSettings.RenderFieldsOfView;
            Managers.CreatureManager.maximumObjects = currentSettings.CreatureAmount;
            Managers.CreatureManager.newGenerationAt = currentSettings.NewGenerationAt;
            Managers.CreatureManager.mutation = (float)(currentSettings.Mutation / 100);
            Managers.FoodManager.maximumObjects = currentSettings.FoodAmount;
            Managers.PoisonManager.maximumObjects = currentSettings.PoisonAmount;

            //Spawn objects
            for (int i = 0; i < Managers.CreatureManager.maximumObjects; i++) Managers.CreatureManager.InsertRandom(new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            for (int i = 0; i < Managers.FoodManager.maximumObjects; i++) Managers.FoodManager.InsertRandom(new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
            for (int i = 0; i < Managers.PoisonManager.maximumObjects; i++) Managers.PoisonManager.InsertRandom(new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            base.Initialize();
        }

        //Loads all the textures, fonts and sounds
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load font
            normalFont = Content.Load<SpriteFont>("font\\normal_font");

            //Load and play music
            music = Content.Load<SoundEffect>("sound\\clean_soul");
            musicInstance = music.CreateInstance();
            musicInstance.IsLooped = true;
            if (currentSettings.PlayMusic) musicInstance.Play();

            //Load textures
            Managers.CreatureManager.LoadContent(this.Content, GraphicsDevice);
            Managers.FoodManager.LoadContent(this.Content);
            Managers.PoisonManager.LoadContent(this.Content);
        }

        #endregion

        #region UserInteraction

        //Disables Fullscreen
        public void DisableFullscreen()
        {
            isFullscreen = false;
            graphics.IsFullScreen = false;
            System.Windows.Forms.Control.FromHandle(this.Window.Handle).Visible = false;
            this.drawSurface = Program.mainForm1.Controls["PanelRender"].Handle;
            graphics.ApplyChanges();
            Program.mainForm1.Focus();
        }

        //Enables Fullscreen
        public void EnableFullscreen()
        {
            isFullscreen = true;
            graphics.IsFullScreen = true;
            drawSurface = this.Window.Handle;
            graphics.ApplyChanges();
        }

        //Plays or pauses the simulation
        public void PlayPause()
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Program.mainForm1.LabelStatus2.Text = "    ||    PAUSED";
            }
            else
            {
                Program.mainForm1.LabelStatus2.Text = "";
            }
        }

        //Handles a click on the form, used for selecting a creature
        public void HandleClick(int X, int Y)
        {
            //Clicks on fullscreen are not being handled here
            if (!isFullscreen)
            {
                selectedCreature = null;
                foreach (SimulationObjects.Creature creature in Managers.CreatureManager.creatures)
                {
                    if (Vector2.Distance(new Vector2(
                        X * (float)((float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (float)Program.mainForm1.Controls["PanelRender"].Width),
                        Y * (float)((float)GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / (float)Program.mainForm1.Controls["PanelRender"].Height)
                        ), creature.Location) <= (creature.Size / 2)) selectedCreature = creature;
                }
            }
        }

        //Windowed form wants to close
        public void Game1_RequestExit(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Settings.SettingsManager.Save(currentSettings, settingsPath);
            this.Exit();
        }

        #endregion

        #region GameLoops

        //No keyrepeat 
        private bool wasf2down;

        //The Update loop
        protected override void Update(GameTime gameTime)
        {
            if (isFullscreen)
            {
                //Handle mouseclick on fullscreen
                MouseState ms = Mouse.GetState();
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    selectedCreature = null;
                    foreach (SimulationObjects.Creature creature in Managers.CreatureManager.creatures)
                    {
                        if (Vector2.Distance(new Vector2(ms.X, ms.Y), creature.Location) <= (creature.Size / 2)) selectedCreature = creature;
                    }
                }

                //Play/pause
                if (Keyboard.GetState().IsKeyDown(Keys.F2) && (wasf2down == false))
                {
                    wasf2down = true;
                    PlayPause();
                }
                if (Keyboard.GetState().IsKeyUp(Keys.F2))
                {
                    wasf2down = false;
                }

                //Switch back to windowed mode
                if (Keyboard.GetState().IsKeyDown(Keys.Escape) || Keyboard.GetState().IsKeyDown(Keys.F4))
                {
                    DisableFullscreen();
                }
            }
            if (!isPaused)
            {
                //Update objects
                Managers.CreatureManager.UpdateAll(gameTime, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
                Managers.FoodManager.UpdateAll(new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
                Managers.PoisonManager.UpdateAll(new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));
                base.Update(gameTime);
            }

        }

        //The render loop
        protected override void Draw(GameTime gameTime)
        {
            //Update statusbar on window
            mainMenu.Items[0].Text = "Population: " + Managers.CreatureManager.creatures.Count().ToString() + "   |   Generation: " + generationCount.ToString();

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //Draw all objects
            Managers.FoodManager.DrawAll(spriteBatch);
            Managers.PoisonManager.DrawAll(spriteBatch);
            Managers.CreatureManager.DrawAll(spriteBatch);

            //Render text if wanted
            if (renderText)
            {
                //General info
                String Info = "  None selected";
                if (selectedCreature != null && selectedCreature.Health > 0)
                {
                    Info = "  X: " + selectedCreature.Location.X.ToString() + Environment.NewLine;
                    Info += "  Y: " + selectedCreature.Location.Y.ToString() + Environment.NewLine;
                    Info += "  Rotation: " + selectedCreature.Rotation.ToString() + Environment.NewLine;
                    Info += "  Velocity: " + selectedCreature.Velocity.ToString() + Environment.NewLine;
                    Info += "  TVelocity: " + selectedCreature.TurningVelocity.ToString() + Environment.NewLine;
                    Info += "  Health: " + selectedCreature.Health.ToString() + Environment.NewLine;
                    Info += "  Clock: " + selectedCreature.Clock.ToString();
                }

                //DNA of creature
                String DNA = "  None selected";
                if (selectedCreature != null && selectedCreature.Health > 0)
                {
                    DNA = "  LEFOw: " + selectedCreature.Weights.LEFOw.LTHR.ToString() + "|" + selectedCreature.Weights.LEFOw.RTHR.ToString() + "|" + selectedCreature.Weights.LEFOw.MTHR.ToString() + Environment.NewLine;
                    DNA += "  REFOw: " + selectedCreature.Weights.REFOw.LTHR.ToString() + "|" + selectedCreature.Weights.REFOw.RTHR.ToString() + "|" + selectedCreature.Weights.REFOw.MTHR.ToString() + Environment.NewLine;
                    DNA += "  LEPOw: " + selectedCreature.Weights.LEPOw.LTHR.ToString() + "|" + selectedCreature.Weights.LEPOw.RTHR.ToString() + "|" + selectedCreature.Weights.LEPOw.MTHR.ToString() + Environment.NewLine;
                    DNA += "  REPOw: " + selectedCreature.Weights.REPOw.LTHR.ToString() + "|" + selectedCreature.Weights.REPOw.RTHR.ToString() + "|" + selectedCreature.Weights.REPOw.MTHR.ToString() + Environment.NewLine;
                    DNA += "  HEALTHw: " + selectedCreature.Weights.HEALTHw.LTHR.ToString() + "|" + selectedCreature.Weights.HEALTHw.RTHR.ToString() + "|" + selectedCreature.Weights.HEALTHw.MTHR.ToString() + Environment.NewLine;
                    DNA += "  CLOCKw: " + selectedCreature.Weights.CLOCKw.LTHR.ToString() + "|" + selectedCreature.Weights.CLOCKw.RTHR.ToString() + "|" + selectedCreature.Weights.CLOCKw.MTHR.ToString();
                }
                spriteBatch.DrawString(normalFont, "Creature info:" + Environment.NewLine + Info + Environment.NewLine + Environment.NewLine + "DNA (LTHR|RTHR|MTHR):" + Environment.NewLine + DNA, new Vector2(10, 10), Color.Black);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }

        #endregion

    }
}
