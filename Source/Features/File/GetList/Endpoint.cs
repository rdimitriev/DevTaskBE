using FastEndpoints;

namespace File.GetList;

public class Endpoint : EndpointWithoutRequest<List<File>>
{
    public override void Configure()
    {
        Get("api/files/");
        Options(x => x.RequireCors(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        try
        {
            List<File> files = await Data.GetList();
            await SendAsync(files, 200, ct);
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