using System.Text.RegularExpressions;
using FastEndpoints;

namespace File.Upload;

public class Request
{
    public required IFormFile XmlFile { get; set; }
}

public class Response
{
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.XmlFile).Cascade(CascadeMode.Continue)
            .NotEmpty().WithMessage("XML file content is required!")
            .Must(x => IsAllowedFilaName(x.FileName)).WithMessage("Invalid file name provided!")
            .Must(x => IsAllowedSize(x.Length)).WithMessage("File size should be between 100B and 10MB!")
            .Must(x => IsAllowedType(x.ContentType)).WithMessage("Uploaded file type is invalid!");

    }

    private static readonly string[] allowedTypes = ["text/xml", "application/xml"];

    public bool IsAllowedFilaName(string fileName)
        => Regex.Match(fileName, @"^[\w\-. ]+$").Success;

    public bool IsAllowedType(string contentType)
        => (allowedTypes).Contains(contentType.ToLower());

    public bool IsAllowedSize(long fileLength)
        => fileLength is >= 100 and <= 10485760;
}
