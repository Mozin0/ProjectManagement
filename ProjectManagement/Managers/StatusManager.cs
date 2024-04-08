using Microsoft.EntityFrameworkCore;
using ProjectManagement.DbContexts;
using ProjectManagement.Dto;
using ProjectManagement.ManagerInterfaces;
using ProjectManagement.Mappers;
using ProjectManagement.Models;

namespace ProjectManagement.Managers
{
    public class StatusManager(ProjectManagementDbContext dbcontext) : IStatusManager
    {
        private readonly ProjectManagementDbContext _dbcontext = dbcontext;

        public IQueryable<StatusDto> GetStatuses()
        {
            var statuses = _dbcontext.Statuses;
            return statuses.Select(s => s.ToDto());
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            return await _dbcontext.Statuses.SingleAsync(s => s.Id == id);
        }

        public async Task<StatusDto> PostStatusAsync(StatusDto statusDto)
        {
           var status = new Status();
           statusDto.ToEntity(status);
           await _dbcontext.Statuses.AddAsync(status);
           await _dbcontext.SaveChangesAsync();
           return status.ToDto();
        }

        public async Task DeleteStatusAsync(int id)
        {
            var status = await GetStatusByIdAsync(id);
            if (status != null)
            {
                _dbcontext.Statuses.Remove(status);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}