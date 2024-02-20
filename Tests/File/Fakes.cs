using Bogus;
using Microsoft.AspNetCore.Http;
using SaveRequest = File.Upload.Request;

namespace Tests.File;

static class Fakes
{
    internal static SaveRequest SaveRequest(this Faker f, string content)
    {
        // Setup mock file using a memory stream
        var fileName = "test.xml";
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(content);
        writer.Flush();
        stream.Position = 0;

        // create FormFile with desired data
        IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form.xml", fileName) {
            Headers = new HeaderDictionary(),
            ContentType = "text/xml"
        };
        
        return new()
        {
            XmlFile = file
        };
    }
}
