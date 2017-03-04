using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using System.IO;

namespace Creatures.SimulationObjects
{

    //Defines a creature
    public class Creature
    {

        #region Attributes

        //Fixed values
        private const float frictionFactor = (float)0.90;
        private const float frictionFactorTurning = (float)0.90;
        public int Size;

        //Position and Rotation
        public Vector2 Location;
        public float Rotation;
        public Color Color;

        //Velocity for realistiv movements
        public float Velocity;
        public float TurningVelocity;

        //Attributes
        public float Health;
        public float Clock;
        public float Age;

        //Brain and DNA
        public Brain.Brain Brain;
        public Brain.DataInput Weights;

        //Used for Push()
        public enum PushDirection
        {
            Middle = 0,
            TurnLeft = 1,
            TurnRight = 2
        }

        #endregion

        #region StartupAndMeta

        //Constructor
        public Creature(Vector2 location, float rotation, Color color, Brain.DataInput weights=null, int size=50)
        {
            this.Location = location;
            this.Rotation = rotation;
            this.Color = color;
            this.Size = size;
            this.Health = 1;
            this.Brain = new Brain.Brain();
            if (weights == null)
            {
                this.Weights = Brain.GenerateRandomWeights();
            }
            else
            {
                this.Weights = weights;
            }
            
        }

        //Pushes the creature, alters the velocity
        public void Push(PushDirection direction, float power)
        {
            switch (direction)
            {
                //Back
                case PushDirection.Middle:
                    if (this.Velocity < 0.05)
                    {
                        this.Velocity += power;
                    }
                    break;
                //Left
                case PushDirection.TurnLeft:
                    if (this.TurningVelocity > -0.1e-6)
                    {
                        this.TurningVelocity -= power;
                    }
                    break;
                //Right
                case PushDirection.TurnRight:
                    if (this.TurningVelocity < 0.1e-6)
                    {
                        this.TurningVelocity += power;
                    }
                    break;
            }

        }

        //Checks if a triangle contains a point
        private bool PointInTriangle(Vector2 pt, Vector2 v1, Vector2 v2, Vector2 v3)
        {
            bool b1, b2, b3;
            b1 = sign(pt, v1, v2) < 0.0f;
            b2 = sign(pt, v2, v3) < 0.0f;
            b3 = sign(pt, v3, v1) < 0.0f;
            return ((b1 == b2) && (b2 == b3));
        }
        //Needed for PointInTriagle()
        private float sign(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        #endregion

        #region GameLoops

        //Update loop, called by manager
        public void Update(GameTime gameTime, Rectangle Bounds)
        {
            //Update Position and Rotation
            this.Rotation = this.Rotation + (float)(this.TurningVelocity * gameTime.ElapsedGameTime.TotalMilliseconds * Program.game.simulationSpeed);
            this.Location = new Vector2(
                (float)(this.Location.X + Math.Cos(this.Rotation) * (this.Velocity * gameTime.ElapsedGameTime.TotalMilliseconds * Program.game.simulationSpeed)),
                (float)(this.Location.Y + Math.Sin(this.Rotation) * (this.Velocity * gameTime.ElapsedGameTime.TotalMilliseconds * Program.game.simulationSpeed))
            );

            //Check for border collision
            if (this.Location.Y <= 0) this.Location.Y = Bounds.Height - 1;
            if (this.Location.Y >= Bounds.Height) this.Location.Y = 1;
            if (this.Location.X <= 0) this.Location.X = Bounds.Width - 1;
            if (this.Location.X >= Bounds.Width) this.Location.X = 1;

            //Calculate Field of view data
            Vector2 FOVcenterEnd = new Vector2((float)(Math.Cos(this.Rotation) * Managers.CreatureManager.LineDirectionLength) + this.Location.X, (float)(Math.Sin(this.Rotation) * Managers.CreatureManager.LineDirectionLength) + this.Location.Y);
            Vector2 FOVrightEnd = new Vector2((float)(Math.Cos(this.Rotation + Managers.CreatureManager.eyeAngle) * Managers.CreatureManager.LineEyeLength) + this.Location.X, (float)(Math.Sin(this.Rotation + Managers.CreatureManager.eyeAngle) * Managers.CreatureManager.LineEyeLength) + this.Location.Y);
            Vector2 FOVleftEnd = new Vector2((float)(Math.Cos(this.Rotation - Managers.CreatureManager.eyeAngle) * Managers.CreatureManager.LineEyeLength) + this.Location.X, (float)(Math.Sin(this.Rotation - Managers.CreatureManager.eyeAngle) * Managers.CreatureManager.LineEyeLength) + this.Location.Y);

            //Check for food in field of view
            int pointsInLE = 0;
            int pointsInRE = 0;
            foreach (Food food in Managers.FoodManager.foods)
            {
                if (PointInTriangle(food.Location, this.Location, FOVcenterEnd, FOVleftEnd)) pointsInLE++; 
                if (PointInTriangle(food.Location, this.Location, FOVcenterEnd, FOVrightEnd)) pointsInRE++;
            }
            if(pointsInLE > 1) pointsInLE = 1;
            if(pointsInLE < 0) pointsInLE = 0;
            if(pointsInRE > 1) pointsInRE = 1;
            if(pointsInRE < 0) pointsInRE = 0;

            //Check for poison in field of view
            float poiPointsInLE = 0;
            float poiPointsInRE = 0;
            foreach (Poison poison in Managers.PoisonManager.poisons)
            {
                if (PointInTriangle(poison.Location, this.Location, FOVcenterEnd, FOVleftEnd)) poiPointsInLE++;
                if (PointInTriangle(poison.Location, this.Location, FOVcenterEnd, FOVrightEnd)) poiPointsInRE++;
            }
            if (poiPointsInLE > 1) poiPointsInLE = 1;
            if (poiPointsInLE < 0) poiPointsInLE = 0;
            if (poiPointsInRE > 1) poiPointsInRE = 1;
            if (poiPointsInRE < 0) poiPointsInRE = 0;

            //Process data
            Brain.DataInput dataToProcess = new Brain.DataInput() { 
                LEFO = pointsInLE, REFO = pointsInRE,  LEPO = poiPointsInLE, REPO = poiPointsInRE, 
                HEALTH = this.Health, CLOCK = this.Clock, 
                LEFOw = this.Weights.LEFOw, REFOw = this.Weights.REFOw, LEPOw = this.Weights.LEPOw, REPOw = this.Weights.REPOw, 
                HEALTHw = this.Weights.HEALTHw, CLOCKw = this.Weights.CLOCKw 
            };
            Brain.DataOutput thrusts = Brain.ProcessData(dataToProcess);

            //Move
            this.Push(PushDirection.Middle, thrusts.MTHR);
            this.Push(PushDirection.TurnLeft, thrusts.LTHR / 50);
            this.Push(PushDirection.TurnRight, thrusts.RTHR / 50);

            //Update attributes
            this.Velocity *= frictionFactor;
            this.TurningVelocity *= frictionFactorTurning;
            this.Health -= (float)0.0008;
            this.Color.A = Convert.ToByte(255 - (255 - (this.Health * 255)));
            this.Clock = (float)(Math.Sin(gameTime.TotalGameTime.TotalMilliseconds * Program.game.simulationSpeed / 50) + 1) / 2;
            this.Age += (1 * Program.game.simulationSpeed);
        }

        #endregion

        
    }

    //Defines a food particle
    public class Food
    {

        #region Attributes

        public Vector2 Location;
        public static int Size = 10;

        #endregion

        public Food(Vector2 loc)
        {
            this.Location = loc;
        }

    }

    //Defines a poison particle
    public class Poison
    {

        #region Attributes

        public Vector2 Location;
        public static int Size = 10;

        #endregion

        public Poison(Vector2 loc)
        {
            this.Location = loc;
        }

    }

}
