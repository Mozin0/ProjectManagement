using Microsoft.EntityFrameworkCore;
using ProjectManagement.DbContexts;
using ProjectManagement.Dto;
using ProjectManagement.Mappers;
using ProjectManagement.Models;

namespace ProjectManagement.Managers;
public class StatusManager(ProjectManagementDbContext dbContext)
{
    private readonly ProjectManagementDbContext _dbContext = dbContext;

    public IEnumerable<StatusDto> GetStatuses()
    {
        var statuses = _dbContext.Statuses;
        return [.. statuses.Select(s => s.ToDto())];
    }

    public async Task<Status> GetStatusByIdAsync(int id)
    {
        return await _dbContext.Statuses.SingleAsync(s => s.Id == id);
    }

    public async Task<StatusDto> PostStatusAsync(StatusDto statusDto)
    {
        var status = new Status();
        statusDto.ToEntity(status);
        await _dbContext.Statuses.AddAsync(status);
        await _dbContext.SaveChangesAsync();
        return status.ToDto();
    }

    public async Task<StatusDto> PutStatusAsync(int id, StatusDto statusDto)
    {
        var status = await GetStatusByIdAsync(id) ?? throw new Exception("Status Doesn't Exist.");
        statusDto.ToEntity(status);
        await _dbContext.SaveChangesAsync();
        return status.ToDto();
    }

    public async Task DeleteStatusAsync(int id)
    {
        var status = await GetStatusByIdAsync(id);
        if (status != null)
        {
            _dbContext.Statuses.Remove(status);
            await _dbContext.SaveChangesAsync();
        }
    }
}