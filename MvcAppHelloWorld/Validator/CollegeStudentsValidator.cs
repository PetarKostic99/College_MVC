using FluentValidation;

namespace MvcAppHelloWorld.Validator
{
    public class CollegeStudentsValidatorModel : AbstractValidator<CollegeViewModel>
    {
        public CollegeStudentsValidatorModel()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(user => user.Lastname).NotEmpty().WithMessage("Last Name is required");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Please enter valid email").NotEmpty().WithMessage("Email is required");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required").Length(4, 8);
            RuleFor(user => user.Birthday_date).NotEmpty().WithMessage("Birthdate is required");

        }
    }
}