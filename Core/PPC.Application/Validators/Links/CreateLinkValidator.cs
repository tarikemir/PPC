using FluentValidation;
using PPC.Application.ViewModels.Links;

namespace PPC.Application.Validators.Links
{
    public class CreateLinkValidator : AbstractValidator<VM_Create_Link>
    {
        public CreateLinkValidator()
        {
            RuleFor(c => c.OriginalUrl)
                .NotEmpty()
                .WithMessage("Can't accept empty link!")
                .MinimumLength(3)
                .WithMessage("Please enter a value that is greater than 3 char!");
        }
    }
}
