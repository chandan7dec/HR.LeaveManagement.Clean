using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Command.DeleteLeaveType
{
    internal class DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository) : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //retrive the record from the database
            var leaveTypeToDelete = await leaveTypeRepository.GetByIdAsync(request.Id);

            //remove from the database.
           await leaveTypeRepository.DeleteAsync(leaveTypeToDelete);

            //verify the record

            return Unit.Value;
        }
    }
}
