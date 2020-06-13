using System.IO;
using System.Xml.Serialization;

namespace SoftwareBase.Serialize
{
    public static class Serialize<T>
    {
        public static XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        public static void SaveData(T obj, string path)
        {
            using (Stream s = File.OpenWrite(path))
                xmlSerializer.Serialize(s, obj);
        }
        public static T LoadData(T obj, string path)
        {
            T result;
            using (Stream s = File.OpenRead(path))
                result = (T)xmlSerializer.Deserialize(s);
            return result;
        }
    }
}
