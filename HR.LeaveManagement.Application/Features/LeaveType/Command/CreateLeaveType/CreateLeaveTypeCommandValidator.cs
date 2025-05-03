using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must not exceed 70 characters.");

            RuleFor(p=> p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} must not be empty.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");

            RuleFor(p => p)
                .MustAsync(LeaveTypeUnique)
                .WithMessage("Leave Type already exists.");

             _leaveTypeRepository = leaveTypeRepository;
        }

        private async Task<bool> LeaveTypeUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
           return await _leaveTypeRepository.isLeaveTypeUnique(command.Name);
        }
    }
}
