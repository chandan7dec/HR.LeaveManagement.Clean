using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository) : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        //public UpdateLeaveTypeCommandHandler()
        //{
            
        //}
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incomming data

            //convert to domain entity object
            var leaveTypeToUpdate = mapper.Map<Domain.LeaveType>(request);

            //add to database
            await leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

            //retun unit value
            return Unit.Value;
        }
    }
}
