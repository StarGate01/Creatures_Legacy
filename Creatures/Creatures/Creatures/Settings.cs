using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Creatures.Settings
{

    //Hols the settings
    public class Settings
    {

        #region Attributes

        //The setable settings
        public int CreatureAmount;
        public int NewGenerationAt;
        public int Mutation;
        public int FoodAmount;
        public int PoisonAmount;
        public int SimulationSpeed;
        public bool PlayMusic;
        public bool RenderFieldsOfView;
        public bool RenderCreatureInformation;

        #endregion

        //Constructor sets the defaults
        public Settings()
        {
            CreatureAmount = 42;
            NewGenerationAt = 6;
            Mutation = 20;
            FoodAmount = 24;
            PoisonAmount = 10;
            SimulationSpeed = 1;
            PlayMusic = true;
            RenderFieldsOfView = false;
            RenderCreatureInformation = true;
        }

    }

    //Serializes and unserializes the settings
    public class SettingsManager
    {

        //Saves the settings to XML
        public static void Save(Settings settings, string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Settings));
            FileStream str = new FileStream(path, FileMode.Create);
            ser.Serialize(str, settings);
            str.Close();
        }

        //Loads the settings from XML
        public static Settings Load(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Settings));
            StreamReader sr = new StreamReader(path);
            Settings settings = (Settings)ser.Deserialize(sr);
            sr.Close();
            return settings;
        }

    }

}
