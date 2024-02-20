using Config;

namespace File.Delete;

static class Data
{
    public static Task DeleteFileFromStorage(string fileName, CancellationToken ct)
    {
        var validationCtx = FastEndpoints.ValidationContext<Request>.Instance;
        string fullFileName = Settings.StoragePath + fileName;

        if (!System.IO.File.Exists(fullFileName))
        {
            validationCtx.ThrowError(r => r.FileName, "Input file does not exist!");
        }

        System.IO.File.Delete(fullFileName);

        return Task.CompletedTask;
    }
}
