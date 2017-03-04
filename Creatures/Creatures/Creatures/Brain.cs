using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Creatures.Brain
{

    #region DataStructures

    //Holds senor input and weights
    public class DataInput
    {

        public float LEFO;
        public float REFO;
        public float LEPO;
        public float REPO;
        public float HEALTH;
        public float CLOCK;
        public DataOutput LEFOw;
        public DataOutput REFOw;
        public DataOutput LEPOw;
        public DataOutput REPOw;
        public DataOutput HEALTHw;
        public DataOutput CLOCKw;

    }

    //Hold brain output
    public class DataOutput
    {

        public float LTHR;
        public float RTHR;
        public float MTHR;

    }

    #endregion

    //Calculates output from input while using weights
    public class Brain
    {

        //Generates a random DNA
        public DataInput GenerateRandomWeights()
        {
            DataInput res = new DataInput();
            res.LEFOw = new DataOutput() { LTHR = (float)Program.game.rnd.NextDouble(), RTHR = (float)Program.game.rnd.NextDouble(), MTHR = (float)Program.game.rnd.NextDouble() };
            res.REFOw = new DataOutput() { LTHR = (float)Program.game.rnd.NextDouble(), RTHR = (float)Program.game.rnd.NextDouble(), MTHR = (float)Program.game.rnd.NextDouble() };
            res.LEPOw = new DataOutput() { LTHR = (float)Program.game.rnd.NextDouble(), RTHR = (float)Program.game.rnd.NextDouble(), MTHR = (float)Program.game.rnd.NextDouble() };
            res.REPOw = new DataOutput() { LTHR = (float)Program.game.rnd.NextDouble(), RTHR = (float)Program.game.rnd.NextDouble(), MTHR = (float)Program.game.rnd.NextDouble() };
            res.HEALTHw = new DataOutput() { LTHR = (float)Program.game.rnd.NextDouble(), RTHR = (float)Program.game.rnd.NextDouble(), MTHR = (float)Program.game.rnd.NextDouble() };
            res.CLOCKw = new DataOutput() { LTHR = (float)Program.game.rnd.NextDouble(), RTHR = (float)Program.game.rnd.NextDouble(), MTHR = (float)Program.game.rnd.NextDouble() };
            return res;
        }
       
        //Processes the data
        public DataOutput ProcessData(DataInput input)
        {
            DataOutput output = new DataOutput();
            output.LTHR = ((input.LEFO * input.LEFOw.LTHR) + (input.REFO * input.REFOw.LTHR) + (input.LEPO * input.LEPOw.LTHR) + (input.REPO * input.REPOw.LTHR) + (input.HEALTH * input.HEALTHw.LTHR) + (input.CLOCK * input.CLOCKw.LTHR)) / 6;
            output.RTHR = ((input.LEFO * input.LEFOw.RTHR) + (input.REFO * input.REFOw.RTHR) + (input.LEPO * input.LEPOw.LTHR) + (input.REPO * input.REPOw.LTHR) + (input.HEALTH * input.HEALTHw.RTHR) + (input.CLOCK * input.CLOCKw.RTHR)) / 6;
            output.MTHR = ((input.LEFO * input.LEFOw.MTHR) + (input.REFO * input.REFOw.MTHR) + (input.LEPO * input.LEPOw.LTHR) + (input.REPO * input.REPOw.LTHR) + (input.HEALTH * input.HEALTHw.MTHR) + (input.CLOCK * input.CLOCKw.MTHR)) / 6;
            return output;
        }

    }

}
