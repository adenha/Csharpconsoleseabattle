using System;
using System.IO;
using Newtonsoft.Json;

namespace SeaBattle
{
    public class HumanPlayer : Player
    {
        public HumanPlayer()
        {

        }
        public void ExportMap(string filename)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter($"{filename}.json"))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, ships);
            }
        }

        public void ExportMap()
        {
            ExportMap("map");
        }
    }
}