using System.Xml;
using Config;
using Newtonsoft.Json;
using NJsonSchema;

namespace File.Upload;

static class Data
{
    public static async Task ProcessFile(IFormFile file)
    {
        var validationCtx = FastEndpoints.ValidationContext<Request>.Instance;

        // validate file more if needed
        if (file is null)
        {
            validationCtx.ThrowError(r => r.XmlFile, "Input file is empty");
        }

        string fileName = Path.ChangeExtension(file.FileName, "json");

        if (System.IO.File.Exists(Path.Combine(Settings.StoragePath, fileName)))
        {
            validationCtx.ThrowError("Converted json file already exists!");
        }

        // convert xml to json
        StreamReader reader = new(file.OpenReadStream());
        string xml = reader.ReadToEnd();

        XmlDocument doc = new();
        doc.LoadXml(xml);
        string jsonText = JsonConvert.SerializeXmlNode(doc);

        // store on disk
        using StreamWriter outputFile = new(Path.Combine(Settings.StoragePath, fileName));
        await outputFile.WriteAsync(jsonText);
    }
}
