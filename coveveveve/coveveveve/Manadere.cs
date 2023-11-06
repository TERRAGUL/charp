using Newtonsoft.Json;
using System.Xml.Serialization;

public class FileManager
{
    private string filePath;

    public FileManager(string filePath)
    {
        this.filePath = filePath;
    }

    public DataModel ReadFile()
    {
        List<string> lines = new List<string>(File.ReadAllLines(filePath));

        return new DataModel(lines);
    }


    public void SaveFile(DataModel data)
    {
        Console.WriteLine("Введи путь к новому файлу, название не забудь и формааат ^_^:");
        string savePath = Console.ReadLine();
        string format = Path.GetExtension(savePath).TrimStart('.');

        try
        {
            switch (format.ToLower())
            {
                case "txt":
                    File.WriteAllLines(savePath, data.Properties);
                    break;
                case "json":
                    string jsonContent = JsonConvert.SerializeObject(data);
                    File.WriteAllText(savePath, jsonContent);
                    break;
                case "xml":
                    XmlSerializer serializer = new XmlSerializer(typeof(DataModel));
                    using (StreamWriter writer = new StreamWriter(savePath))
                    {
                        serializer.Serialize(writer, data);
                    }
                    break;
                default:
                    throw new NotSupportedException($"Unsupported file format: {format}");
            }
            Console.WriteLine("Файл успешно сохранен.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
        }
    }
}
