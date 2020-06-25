using System.IO;
using System.Xml.Serialization;

namespace SoftwareBase.Serialize
{
    /// <summary>
    /// Saves and loads data
    /// </summary>
    /// <typeparam name="T">Type of data</typeparam>
    public static class Serialize<T>
    {
        private static XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        /// <summary>
        /// Creates or Overrides data
        /// </summary>
        /// <param name="obj">Datas to save</param>
        /// <param name="path">Path of datas</param>
        public static void SaveData(T obj, string path)
        {
            using (Stream s = File.Create(path))
                xmlSerializer.Serialize(s, obj);
        }
        /// <summary>
        /// Loads data
        /// </summary>
        /// <param name="path">Path of data</param>
        /// <returns>T</returns>
        public static T LoadData(string path)
        {
            T result;
            using (Stream s = File.OpenRead(path))
                result = (T)xmlSerializer.Deserialize(s);
            return result;
        }
    }
}
