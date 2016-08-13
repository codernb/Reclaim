
using Assets.Scripts.Models.Map;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    class MapReader
    {

        public static string[] getMapNames()
        {
            if (!Directory.Exists(MapWriter.MAPS_FOLDER))
                return new string[0];
            var mapNames = Directory.GetFiles(MapWriter.MAPS_FOLDER);
            for (int i = 0; i < mapNames.Length; i++)
                mapNames[i] = mapNames[i].Split('\\')[1];
            return mapNames;
        }

        public static Map load(string name)
        {
            var binaryFormatter = new BinaryFormatter();
            var fileStream = File.Open(MapWriter.MAPS_FOLDER + "/" + name, FileMode.Open);
            var map = (Map) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            return map;
        }

    }
}
