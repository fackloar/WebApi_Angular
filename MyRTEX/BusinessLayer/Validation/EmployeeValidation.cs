using FluentValidation;
using MyRTEX.BusinessLayer.DTOs;
using System.Text.RegularExpressions;

namespace MyRTEX.BusinessLayer.Validation
{
    public class EmployeeValidation : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidation()
        {
            RuleFor(e => e.EmployeeSalary)
                .NotNull()
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be more than 0")
                .WithErrorCode("ID-000");
            RuleFor(e => e.EmployeeName)
                .NotNull()
                .Must(n => Regex.IsMatch(n, "[a-zA-Zа-яёА-ЯЁ ]"))
                .WithMessage("{PropertyName} must be in Russian or English")
                .WithErrorCode("NAME-001");
        }
    }
}
