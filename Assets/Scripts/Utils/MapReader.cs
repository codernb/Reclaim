
using Assets.Scripts.Models.Map;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Assets.Scripts.Utils
{
    class MapReader
    {

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
