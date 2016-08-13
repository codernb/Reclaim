using Assets.Scripts.Models.Map;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assets.Scripts.Utils
{
    class MapWriter
    {

        public static readonly string MAPS_FOLDER = "Maps";

        public static void save(Map map)
        {
            if (!Directory.Exists(MAPS_FOLDER))
                Directory.CreateDirectory(MAPS_FOLDER);
            var binaryFormatter = new BinaryFormatter();
            var fileStream = File.Create(MAPS_FOLDER + "/" + map.name);
            binaryFormatter.Serialize(fileStream, map);
            fileStream.Close();
        }

    }
}
