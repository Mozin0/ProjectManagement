using Riok.Mapperly.Abstractions;
using ProjectManagement.Dto;
using ProjectManagement.Models;
using System.Linq;

namespace ProjectManagement.Mappers;
public static partial class TaskMapper 
{
    /// <summary>
    /// Maps a ProjectTask entity to a ProjectTaskDto.
    /// </summary>
    /// <param name="task">The task entity to map.</param>
    /// <returns>A data transfer object representing the task.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the provided task is null.</exception>
    private static ProjectTaskDto MapEntityToDto(ProjectTask task)
    {
        if (task is null) 
        {
            throw new ArgumentNullException(nameof(task), "Task cannot be null.");
        } 

        return new ProjectTaskDto
        {
            Id = task.Id, // Include the ID for retrieval scenarios
            Name = task.Name,
            CreatedDate = task.CreatedDate,
            ProjectID = task.ProjectID,
            Project = task.Project?.ToDto(),
            ParentTaskId = task.ParentTaskId,
            ParentTask = task.ParentTask?.ToDto(),
            StatusId = task.StatusId,
            Status = task.Status?.ToDto(),
            SubTasks = task.SubTasks?.Select(MapEntityToDto).ToList() // Recursively map subtasks
        };
    }

    /// <summary>
    /// Maps a ProjectTaskDto to a ProjectTask entity.
    /// </summary>
    /// <param name="taskDto">The task DTO to map.</param>
    /// <param name="task">The task entity to populate.</param>
    /// <returns>The populated task entity.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the input taskDto or task is null.</exception>
    private static ProjectTask MapDtoToEntity(ProjectTaskDto taskDto, ProjectTask task)
    {
        if (taskDto is null) 
        {
            throw new ArgumentNullException(nameof(taskDto), "Task DTO cannot be null.");
        } 

        if (task is null)
        {
            throw new ArgumentNullException(nameof(task), "Task entity cannot be null.");
        }

        task.Name = taskDto.Name;
        task.CreatedDate = taskDto.CreatedDate;
        task.ProjectID = taskDto.ProjectID;
        task.Project = taskDto.Project?.ToEntity(new Project());
        task.StatusId = taskDto.StatusId;
        task.Status = taskDto.Status?.ToEntity(new Status());
        task.ParentTaskId = taskDto.ParentTaskId;
        if (taskDto.SubTasks is not null)
        {
            task.SubTasks = [];
            foreach (var subTaskDto in taskDto.SubTasks)
            {
                task.SubTasks.Add(MapDtoToEntity(subTaskDto, new ProjectTask()));
            }
        }
        return task;
    }

    /// <summary>
    /// Extension method to convert a ProjectTaskDto to a ProjectTask entity.
    /// </summary>
    /// <param name="taskDto">The DTO to convert.</param>
    /// <param name="task">The entity to populate.</param>
    /// <returns>The populated entity.</returns>
    public static ProjectTask ToEntity(this ProjectTaskDto taskDto, ProjectTask task)
    {
        return MapDtoToEntity(taskDto, task);
    }

    /// <summary>
    /// Extension method to convert a ProjectTask to a ProjectTaskDto.
    /// </summary>
    /// <param name="task">The task entity to convert.</param>
    /// <returns>The corresponding DTO.</returns>
    public static ProjectTaskDto ToDto(this ProjectTask task)
    {
        return MapEntityToDto(task);
    }
}
