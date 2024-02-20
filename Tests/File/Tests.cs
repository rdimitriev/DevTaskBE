using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Delete = File.Delete;
using Get = File.Get;
using List = File.GetList;
using Upload = File.Upload;

namespace Tests.File;

public class Tests(Fixture f, ITestOutputHelper o) : TestClass<Fixture>(f, o)
{
    [Fact]
    public async Task Invalid_File_Data()
    {
        // Setup mock file using a memory stream
        var content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><note><to>Tove</to><From>Jani</From></note>";
        var req = Fake.SaveRequest(content);

        var (rsp, res) = await Fixture.Client.POSTAsync<Upload.Endpoint, Upload.Request, ErrorResponse>(req, true);

        rsp.IsSuccessStatusCode.Should().BeFalse();
        res.Errors.Count.Should().Be(1);
        res.Errors.Keys.Should().Equal("xmlFile");
    }

    [Fact, Priority(1)]
    public void Create_New_Files()
    {

    }

    [Fact, Priority(2)]
    public void Get_Files_List()
    {

    }

    [Fact, Priority(3)]
    public void Get_File()
    {

    }

    [Fact, Priority(4)]
    public void Delete_File()
    {

    }
}