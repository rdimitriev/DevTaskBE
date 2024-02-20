using System.Linq.Expressions;
using Config;

namespace File.GetList;

static class Data
{
    internal static Task<List<File>> GetList()
    {
        List<string> filePaths = new(Directory.EnumerateFiles(Settings.StoragePath, "*." + Settings.TargetExtension));
        List<File> fileAttributes = [];
        
        foreach (string filePath in filePaths)
        {
            string name = Path.GetFileName(filePath);
            
            FileInfo fi = new(filePath);
            long size = fi.Length;
            
            DateTime createdOn = System.IO.File.GetCreationTime(filePath);

            fileAttributes.Add
            (
                new File
                {
                    Name = name,
                    Size = size,
                    CreatedOn = createdOn
                }
            );
        }

        return Task.FromResult(fileAttributes);
    }
}
