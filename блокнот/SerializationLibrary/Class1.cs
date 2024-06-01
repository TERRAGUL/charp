using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SerializationLibrary
{
    public class Serializer
    {
        public static void Serialize<T>(string filePath, List<T> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        public static List<T> Deserialize<T>(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }


    public class FileManager
    {
        public static void Serialize<T>(string filePath, List<T> data)
        {
            var jsonData = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        public static List<T> Deserialize<T>(string filePath)
        {
            if (!File.Exists(filePath)) return new List<T>();
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
    }
}