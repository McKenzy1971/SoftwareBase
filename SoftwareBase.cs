using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace SoftwareBase
{
    public static class XmlSerialiazer<T>
    {
        public static XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

        public static void Serialize(string path, Object obj)
        {
            using (Stream s = File.OpenWrite(path))
                xmlSerializer.Serialize(s, obj);
        }

        public static T[] Deserialize(string path)
        {
            using (Stream s = File.OpenRead(path))
            {
                T[] objects = (T[])xmlSerializer.Deserialize(s);
                return objects;
            }
        }
    }
}
