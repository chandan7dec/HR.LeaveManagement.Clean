using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Query.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Query.GetLeaveTypeDetails;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public  class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
                
        }
    }
}
