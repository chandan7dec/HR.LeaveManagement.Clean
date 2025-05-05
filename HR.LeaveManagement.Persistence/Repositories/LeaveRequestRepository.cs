using HR.LeaveManagement.Application.Contracts.Persistance;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {

        }

        public Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            var leaveRequests = _context.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequests = await _context.LeaveRequests
                .Include( q => q.LeaveType ).ToListAsync();
            return leaveRequests;
        }

        public Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId)
        {
            var leaveRequests = _context.LeaveRequests
                .Where( q => q.RequestingEmployeeId == userId )
                .Include( q => q.LeaveType )
                .ToListAsync();
            return leaveRequests;
        }
    }
}
