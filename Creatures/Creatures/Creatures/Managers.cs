using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

//Static managers for simulation objects
namespace Creatures.Managers
{

    //Manages all creatures
    class CreatureManager
    {

        #region Attributes

        //The creature list
        public static int maximumObjects;
        public static List<SimulationObjects.Creature> creatures = new List<SimulationObjects.Creature>(); 
        public static int newGenerationAt;
        public static float mutation;

        //Attributes for the vield of view
        public static int LineDirectionLength = 200;
        public static int LineEyeLength = 200;
        public static float eyeAngle = (float)(Math.PI / 3.5);

        #endregion

        #region StartupAndMeta

        //Invokes the renderer to load its textures
        public static void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
           Renderers.CreatureRenderer.LoadContent(content, graphics);
        }

        //Inserts a random creature
        public static void InsertRandom(Rectangle bounds)
        {
            //Random size
            int siz = 50 + Program.game.rnd.Next(-7, 7);

            //Add it to the list
            creatures.Add(new SimulationObjects.Creature(
                new Vector2(
                    (float)Program.game.rnd.Next(siz, bounds.Width - siz),
                    (float)Program.game.rnd.Next(siz, bounds.Height - siz)
                ),
                (float)(Program.game.rnd.NextDouble() * (Math.PI * 2)),
                Color.FromNonPremultiplied(Program.game.rnd.Next(0, 255), Program.game.rnd.Next(0, 255), Program.game.rnd.Next(0, 255), 255),
                null,
                siz
            ));
        }

        //Mutates the Brain
        public static Brain.DataInput MutateWeights(Brain.DataInput data, float mutationFactor)
        {
            data.LEFOw.LTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.LEFOw.RTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.LEFOw.MTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;

            data.REFOw.LTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.REFOw.RTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.REFOw.MTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;

            data.LEPOw.LTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.LEPOw.RTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.LEPOw.MTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;

            data.REPOw.LTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.REPOw.RTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.REPOw.MTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;

            data.HEALTHw.LTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.HEALTHw.RTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.HEALTHw.MTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;

            data.CLOCKw.LTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.CLOCKw.RTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;
            data.CLOCKw.MTHR += (float)((Program.game.rnd.NextDouble() * 2) - 1) * mutationFactor;

            return data;
        }

        #endregion

        #region GameLoops

        //Update every creature in the list
        public static void UpdateAll(GameTime gameTime, Rectangle bounds)
        {
            List<SimulationObjects.Creature> okayElements = new List<SimulationObjects.Creature>();
            foreach (SimulationObjects.Creature creature in creatures)
            {
                //Check if dead
                if (creature.Health > 0)
                {
                    creature.Update(gameTime, bounds);
                    okayElements.Add(creature);
                }
            }
            creatures = okayElements;

            //Check if generation over
            if (creatures.Count <= newGenerationAt)
            {
                Program.game.generationCount++;
                List<SimulationObjects.Creature> newElements = new List<SimulationObjects.Creature>();
                foreach(SimulationObjects.Creature creature in creatures)
                {
                    //Spawn mutated children
                    for(int i=0; i<(int)((maximumObjects - newGenerationAt) / newGenerationAt); i++)
                    {
                        newElements.Add(new SimulationObjects.Creature(creature.Location, (float)(Program.game.rnd.NextDouble() * (Math.PI * 2)), creature.Color, MutateWeights(creature.Weights, (float)(i / ((maximumObjects - newGenerationAt) / newGenerationAt)) * mutation), 50 + Program.game.rnd.Next(-7, 7)));
                    }
                }
                creatures.Clear();
                creatures = newElements;
                int creaturesCountOld = creatures.Count();
                
                //Fill population up to max
                for (int i = 0; i < (maximumObjects - creaturesCountOld); i++)
                {
                    InsertRandom(bounds);
                }
            }
        }

        //Draws every creature in the list
        public static void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (SimulationObjects.Creature creature in creatures)
            {
                Renderers.CreatureRenderer.Draw(creature, spriteBatch, (Program.game.selectedCreature == creature));
            }
        }

        #endregion

    }

    //Manages the food
    class FoodManager
    {

        #region Attributes

        //The food list
        public static List<SimulationObjects.Food> foods = new List<SimulationObjects.Food>();
        public static int maximumObjects;

        #endregion

        #region StartupAndMeta

        //Invoke the renderer to load its textures
        public static void LoadContent(ContentManager content)
        {
            Renderers.FoodRenderer.LoadContent(content);
        }

        //Inserts a random food particle into the list
        public static void InsertRandom(Rectangle bounds)
        {
            foods.Add(new SimulationObjects.Food(new Vector2(
                (float)Program.game.rnd.Next((SimulationObjects.Food.Size / 2), bounds.Width - (SimulationObjects.Food.Size / 2)),
                (float)Program.game.rnd.Next((SimulationObjects.Food.Size / 2), bounds.Height - (SimulationObjects.Food.Size / 2))
            )));
        }

        #endregion

        #region GameLoops

        //Updates every food in the list
        public static void UpdateAll(Rectangle bounds)
        {
           
            foreach (SimulationObjects.Creature creature in Managers.CreatureManager.creatures)
            { 
                List<SimulationObjects.Food> okayElements = new List<SimulationObjects.Food>();
                foreach (SimulationObjects.Food food in foods)
                { 
                    //Check if eaten
                    if (Vector2.Distance(creature.Location, food.Location) <= ((creature.Size / 2) + (SimulationObjects.Food.Size / 2)))
                    {
                        creature.Health += (float)0.2;
                        if (creature.Health > 1) creature.Health = 1;
                    }
                    else
                    {
                        okayElements.Add(food);
                    }
                }
                foods = okayElements;
                int foodsCountOld = foods.Count();

                //Fill up the list
                for (int i = 0; i < (maximumObjects - foodsCountOld); i++)
                {
                    InsertRandom(bounds);
                }
            }
            
        }

        //Draws every food in the list
        public static void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (SimulationObjects.Food food in foods)
            {
                Renderers.FoodRenderer.Draw(food, spriteBatch);
            }
        }

        #endregion

    }

    //Manages the poison
    class PoisonManager
    {

        #region Attributes

        //The poison list
        public static List<SimulationObjects.Poison> poisons = new List<SimulationObjects.Poison>();
        public static int maximumObjects;

        #endregion

        #region StartupAndMeta

        //Invokes the renderer to load its textures
        public static void LoadContent(ContentManager content)
        {
            Renderers.PoisonRenderer.LoadContent(content);
        }

        //Inserts a random poison particle into the list
        public static void InsertRandom(Rectangle bounds)
        {
            poisons.Add(new SimulationObjects.Poison(new Vector2(
                (float)Program.game.rnd.Next((SimulationObjects.Food.Size / 2), bounds.Width - (SimulationObjects.Food.Size / 2)),
                (float)Program.game.rnd.Next((SimulationObjects.Food.Size / 2), bounds.Height - (SimulationObjects.Food.Size / 2))
            )));
        }

        #endregion

        #region GameLoops

        //Updates every poison in the list
        public static void UpdateAll(Rectangle bounds)
        {

            foreach (SimulationObjects.Creature creature in Managers.CreatureManager.creatures)
            {
                List<SimulationObjects.Poison> okayElements = new List<SimulationObjects.Poison>();
                foreach (SimulationObjects.Poison poison in poisons)
                {
                    //Checks if eaten
                    if (Vector2.Distance(creature.Location, poison.Location) <= ((creature.Size / 2) + (SimulationObjects.Poison.Size / 2)))
                    {
                        creature.Health = 0; ;
                    }
                    else
                    {
                        okayElements.Add(poison);
                    }
                }
                poisons = okayElements;
                int poisonsCountOld = poisons.Count();

                //Fill up the list
                for (int i = 0; i < (maximumObjects - poisonsCountOld); i++)
                {
                    InsertRandom(bounds);
                }
            }

        }

        //Draws every poison on the list
        public static void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (SimulationObjects.Poison poison in poisons)
            {
                Renderers.PoisonRenderer.Draw(poison, spriteBatch);
            }
        }

        #endregion

    }

}
