using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mappper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mappper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mappper = mappper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if(!validationResult.IsValid)
                throw new BadRequestException("Invalid Leave Type", validationResult);

            //convert to domain entity object
            var leaveTypeToCreate = _mappper.Map<Domain.LeaveType>(request);

            //add to database
            await _leaveTypeRepository.CreateAsync(leaveTypeToCreate);


            //return the id of the created object
            return leaveTypeToCreate.Id;
        }
    }
}
