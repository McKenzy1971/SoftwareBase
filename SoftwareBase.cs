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

        public static Object[] Deserialize(string path)
        {
            using (Stream s = File.OpenRead(path))
            {
                Object[] objects = (Object[])xmlSerializer.Deserialize(s);
                return objects;
            }
        }
    }
}
