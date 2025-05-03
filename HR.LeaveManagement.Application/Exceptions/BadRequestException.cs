using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions
{
    public class  BadRequestException : Exception
    {
        public BadRequestException(string messssage) : base(messssage)
        {
            
        }

        public BadRequestException(string messssage, ValidationResult validationResult) : base(messssage)
        {
            ValidationErrors = new();
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }
        }

        public List<string> ValidationErrors { get; set; }

    }
}
