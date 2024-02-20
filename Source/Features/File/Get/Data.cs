using System.IO.Pipelines;
using Config;

namespace File.Get;

static class Data
{
    public static async Task ReadFileFromStorage(string fileName, Stream stream, CancellationToken ct)
    {
        var validationCtx = FastEndpoints.ValidationContext<Request>.Instance;
        string fullFileName = Settings.StoragePath + fileName;

        if (!System.IO.File.Exists(fullFileName))
        {
            validationCtx.ThrowError(r => r.FileName, "Input file does not exist!");
        }

        var file = System.IO.File.Open(fullFileName, FileMode.Open);
        await file.CopyToAsync(stream, ct);
        file.Close();
    }
}
