using FastEndpoints;

namespace File.GetList;

public class File
{
    public required string Name { get; set; }
    public required long Size { get; set; }
    public DateTime CreatedOn { get; set; }
}
