using FastEndpoints;

namespace File.Get;

public class Request
{
    public required string FileName { get; set; }
}

public class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.FileName)
            .NotEmpty().WithMessage("File name is required!")
            .Matches(@"^[\w\-. ]+$").WithMessage("Invalid file name provided!")
            .MaximumLength(200).WithMessage("File name is too long!");
    }
}
