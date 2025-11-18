using FluentValidation;
using SoftChoiceApp.API.Models.DTOs.UserManagementDTO;

namespace SoftChoiceApp.API.Services.Validations.Users
{
    public class CreateUserValidator : AbstractValidator<UsersCreateDto>
    {
        public CreateUserValidator() 
        {
            RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Matches("^[A-Za-z]+$").WithMessage("First name must contain letters only.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .Matches("^[A-Za-z]+$").WithMessage("Last name must contain letters only.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .Matches("^(?![0-9])(?![0-9]+$)[A-Za-z0-9._/]+$")
                .WithMessage("Username must contain letters/numbers/._/ and cannot start with a number or be only numbers.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^A-Za-z0-9]).{8,12}$")
                .WithMessage("Password must be 8–12 characters with upper, lower, number, and special character.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Matches("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$")
                .WithMessage("Invalid email format.");
        }
    }
}
