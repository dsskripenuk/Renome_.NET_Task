using System.Xml;
using Newtonsoft.Json;

Console.WriteLine("Enter the path to the input XML file:");
string inputXmlPath = Console.ReadLine();

Console.WriteLine("Enter the path to the output JSON file:");
string outputJsonPath = Console.ReadLine();

if (!File.Exists(inputXmlPath))
{
    Console.WriteLine("Input XML file does not exist.");
    return;
}

Convert(inputXmlPath, outputJsonPath);

void Convert(string inputXmlPath, string outputJsonPath)
{
    try
    {
        string xmlContent = File.ReadAllText(inputXmlPath);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlContent);

        string json = JsonConvert.SerializeXmlNode(xmlDoc, Newtonsoft.Json.Formatting.Indented);

        File.WriteAllText(outputJsonPath, json);

        Console.WriteLine("XML to JSON conversion completed. Output written to: " + outputJsonPath);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}
