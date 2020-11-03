using System.IO;
using System.Xml.Serialization;

namespace SoftwareBase.Data
{
    /// <summary>
    /// Saves and loads XMl files
    /// </summary>
    /// <typeparam name="T">Type of object</typeparam>
    public static class Serialize<T>
    {
        private static readonly XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        /// <summary>
        /// Creates or Overrides file
        /// </summary>
        /// <param name="obj">File to save</param>
        /// <param name="path">Path of file</param>
        public static void SaveData(T obj, string path)
        {
            using (Stream s = File.Create(path))
                xmlSerializer.Serialize(s, obj);
        }
        /// <summary>
        /// Loads object (T)
        /// </summary>
        /// <param name="path">Filepath</param>
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
