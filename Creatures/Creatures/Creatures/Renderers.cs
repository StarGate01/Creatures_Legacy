using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

//satic renderers for simulation objects
namespace Creatures.Renderers
{

    //Renders a creature
    class CreatureRenderer
    {

        #region Attributes

        //Textures
        private static Texture2D texHead;
        private static Texture2D texBorder;
        private static Texture2D texLine;

        //Attributes
        public static bool renderFOV = false;

        //Used for making the selection frame spinning
        private static int selectionTick = 0;

        #endregion

        #region StartupAndMeta

        //Loads the textures
        public static void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            texHead = content.Load<Texture2D>("img\\creature");
            texBorder = content.Load<Texture2D>("img\\border");
            texLine = new Texture2D(graphics, 1, 1, false, SurfaceFormat.Color);
            texLine.SetData(new[] { Color.White });
        }

        #endregion

        #region GameLoops

        //Draws a creature
        public static void Draw(SimulationObjects.Creature creature, SpriteBatch spriteBatch, bool border=false)
        {
            if (renderFOV)
            {
                //Render the creatures' field of view
                Vector2 endM = new Vector2((float)(Math.Cos(creature.Rotation) * Managers.CreatureManager.LineDirectionLength) + creature.Location.X, (float)(Math.Sin(creature.Rotation) * Managers.CreatureManager.LineDirectionLength) + creature.Location.Y);
                Vector2 endR = new Vector2((float)(Math.Cos(creature.Rotation + Managers.CreatureManager.eyeAngle) * Managers.CreatureManager.LineEyeLength) + creature.Location.X, (float)(Math.Sin(creature.Rotation + Managers.CreatureManager.eyeAngle) * Managers.CreatureManager.LineEyeLength) + creature.Location.Y);
                Vector2 endL = new Vector2((float)(Math.Cos(creature.Rotation - Managers.CreatureManager.eyeAngle) * Managers.CreatureManager.LineEyeLength) + creature.Location.X, (float)(Math.Sin(creature.Rotation - Managers.CreatureManager.eyeAngle) * Managers.CreatureManager.LineEyeLength) + creature.Location.Y);
                DrawLine(spriteBatch, 1, Color.Red, creature.Location, endM);
                DrawLine(spriteBatch, 1, Color.Blue, creature.Location, endR);
                DrawLine(spriteBatch, 1, Color.Blue, creature.Location, endL);
                DrawLine(spriteBatch, 1, Color.Orange, endM, endR);
                DrawLine(spriteBatch, 1, Color.Orange, endM, endL);
            }

            if (border)
            {
                //Render the selection frame
                int bsize = (int)(texBorder.Width * (float)((float)creature.Size / (float)texHead.Width));
                spriteBatch.Draw(texBorder, new Rectangle((int)creature.Location.X, (int)creature.Location.Y, bsize, bsize), null, Color.White, (float)selectionTick / 70, new Vector2((texBorder.Width / 2), (texBorder.Height / 2)), SpriteEffects.None, 0);
                selectionTick++;
            }

            //Render the cerature
            spriteBatch.Draw(texHead, new Rectangle((int)creature.Location.X, (int)creature.Location.Y, creature.Size, creature.Size), null, creature.Color, Convert.ToSingle(creature.Rotation + (Math.PI / 2)), new Vector2((texHead.Width / 2), (texHead.Height / 2)), SpriteEffects.None, (float)0.5);
        }

        //Draws a line, Used by Draw()
        private static void DrawLine(SpriteBatch batch, float width, Color color, Vector2 point1, Vector2 point2)
        {
            float angle = (float)Math.Atan2(point2.Y - point1.Y, point2.X - point1.X);
            float length = Vector2.Distance(point1, point2);
            batch.Draw(texLine, point1, null, color, angle, Vector2.Zero, new Vector2(length, width), SpriteEffects.None, 0);
        }

        #endregion

    }

    //Renders a food particle
    class FoodRenderer
    {

        #region Attributes

        //Texture
        private static Texture2D texFood;

        #endregion

        #region StartupAndMeta

        //Loads the texture
        public static void LoadContent(ContentManager content)
        {
            texFood = content.Load<Texture2D>("img\\particle");
        }

        #endregion

        #region GameLoops

        //Draws the food particle
        public static void Draw(SimulationObjects.Food food, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texFood, new Rectangle((int)food.Location.X, (int)food.Location.Y, SimulationObjects.Food.Size, SimulationObjects.Food.Size), null, Color.Green, 0, new Vector2((texFood.Width / 2), (texFood.Height / 2)), SpriteEffects.None, 1);
        }

        #endregion

    }

    //Renders a poison particle
    class PoisonRenderer
    {

        #region Attributes

        //Texture
        private static Texture2D texPoison;

        #endregion

        #region StartupAndMeta

        //Loads the texture
        public static void LoadContent(ContentManager content)
        {
            texPoison = content.Load<Texture2D>("img\\particle");
        }

        #endregion

        #region GameLoops

        //draws the poison particle
        public static void Draw(SimulationObjects.Poison poison, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texPoison, new Rectangle((int)poison.Location.X, (int)poison.Location.Y, SimulationObjects.Poison.Size, SimulationObjects.Poison.Size), null, Color.Red, 0, new Vector2((texPoison.Width / 2), (texPoison.Height / 2)), SpriteEffects.None, 1);
        }

        #endregion

    }

}
