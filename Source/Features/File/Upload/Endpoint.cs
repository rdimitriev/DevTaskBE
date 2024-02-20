using FastEndpoints;

namespace File.Upload;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/files/");
        Options(x => x.RequireCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        AllowAnonymous();
        AllowFileUploads();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            await Data.ProcessFile(file: req.XmlFile);
            await SendNoContentAsync(ct);
        }
        catch (Exception e)
        {
            if (!ValidationFailed) {
                AddError(e.Message);
            }
            await SendErrorsAsync(400, ct);
        }
    }
}