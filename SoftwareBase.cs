using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;

namespace SoftwareBase
{
    public static class Serialize<T>
    {
        public static XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    }
}
