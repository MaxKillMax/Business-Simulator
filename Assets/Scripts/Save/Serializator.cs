using System.IO;
using Newtonsoft.Json;

namespace BusinessSimulator
{
    public static class Serializator
    {
        public static T Load<T>(string path)
        {
            if (!File.Exists(path))
                return default;

            string content = File.ReadAllText(path);
            T serializeObject = JsonConvert.DeserializeObject<T>(content);
            return serializeObject;
        }

        public static void Save<T>(T serializeObject, string path)
        {
            //if (!Directory.Exists(path))
            //    Directory.CreateDirectory(path);

            //if (!File.Exists(path))
            //    File.Create(path);

            string content = JsonConvert.SerializeObject(serializeObject);
            File.WriteAllText(path, content);
        }
    }
}
