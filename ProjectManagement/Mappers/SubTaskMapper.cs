using ProjectManagement.Dto;
using ProjectManagement.Models;

namespace ProjectManagement.Mappers
{
    public static class SubTaskMapper
    {
        public static List<ProjectTaskDto> MapSubTasks(List<ProjectTask> subTasks)
        {
            // Mapping logic for subtasks
            return subTasks.Select(task => task.ToDto()).ToList();
        }
    }

}