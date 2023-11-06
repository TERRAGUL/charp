public class DataModel
{
    public List<string> Properties { get; set; }

    public DataModel()
    {
        Properties = new List<string>();
    }

    public DataModel(List<string> properties)
    {
        Properties = properties;
    }
}