using FastEndpoints;

namespace File.Delete;

sealed class Endpoint : Endpoint<Request>
{
    public override void Configure()
    {
        Delete("/api/files/{@name}", r => new { r.FileName });
        Options(x => x.RequireCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {
        try
        {
            await Data.DeleteFileFromStorage(req.FileName, ct);
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