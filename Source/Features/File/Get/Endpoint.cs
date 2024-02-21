using FastEndpoints;

namespace File.Get;

public class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Get("/api/files/{@name}", r => new { r.FileName });
        Options(x => x.RequireCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            HttpContext.MarkResponseStart();
            HttpContext.Response.StatusCode = 200;
            await Data.ReadFileFromStorage(req.FileName, HttpContext.Response.Body, ct);
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