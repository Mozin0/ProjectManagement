using ProjectManagement.Dto;
using ProjectManagement.Models;

namespace ProjectManagement.ManagerInterfaces
{
    public interface IStatusManager
    {
        public IQueryable<StatusDto> GetStatuses();
        public Task<Status> GetStatusByIdAsync(int id);
        public Task<StatusDto> PostStatusAsync(StatusDto statusDto);
        public Task DeleteStatusAsync(int id);
    }
}