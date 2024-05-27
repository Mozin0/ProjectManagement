using ProjectManagement.Dto;
using ProjectManagement.Models;

namespace ProjectManagement.Mappers
{
    /// <summary>
    /// Provides methods to map between <see cref="Project"/> entity and <see cref="ProjectDto"/> DTO.
    /// </summary>
    public static partial class ProjectMapper 
    {
        /// <summary>
        /// Maps a <see cref="Project"/> entity to a <see cref="ProjectDto"/>.
        /// </summary>
        /// <param name="project">The <see cref="Project"/> entity to map.</param>
        /// <returns>The mapped <see cref="ProjectDto"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="project"/> is null.</exception>
        private static ProjectDto MapEntityToDto(Project project)
        {
            // Check if the project is null
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project), "Project entity cannot be null.");
            }

            // Map the properties of the Project entity to the corresponding properties of ProjectDto
            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                CreatedDate = project.CreatedDate,
                Deadline = project.Deadline,
                Tasks = project.Tasks?.Select(p => p.ToDto()).ToList(),
                StatusId = project.StatusId,
                Status = project.Status?.ToDto()
            };
        }

        /// <summary>
        /// Maps a <see cref="ProjectDto"/> to a <see cref="Project"/> entity.
        /// </summary>
        /// <param name="projectDto">The <see cref="ProjectDto"/> to map.</param>
        /// <param name="project">The target <see cref="Project"/> entity to map to.</param>
        /// <returns>The mapped <see cref="Project"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either the <paramref name="project"/> or <paramref name="projectDto"/> is null.</exception>
        private static Project MapDtoToEntity(ProjectDto projectDto, Project project)
        {
            // Check if either the project or projectDto is null
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project), "Project entity cannot be null.");
            }
            if (projectDto is null)
            {
                throw new ArgumentNullException(nameof(projectDto), "ProjectDto cannot be null.");
            }

            // Map the properties of ProjectDto to the corresponding properties of the Project entity
            project.Name = projectDto.Name;
            project.CreatedDate = projectDto.CreatedDate;
            project.Deadline = projectDto.Deadline;            
            // Map tasks if present, otherwise initialize to an empty list
            project.Tasks = projectDto.Tasks?.Select(dto => dto.ToEntity(new ProjectTask())).ToList() ?? new List<ProjectTask>();
            project.StatusId = projectDto.StatusId;
            project.Status = projectDto.Status?.ToEntity(new Status());

            return project;
        }

        /// <summary>
        /// Extension method to convert a <see cref="ProjectDto"/> to a <see cref="Project"/> entity.
        /// </summary>
        /// <param name="projectDto">The <see cref="ProjectDto"/> to convert.</param>
        /// <param name="project">The target <see cref="Project"/> entity to map to.</param>
        /// <returns>The mapped <see cref="Project"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="project"/> is null.</exception>
        public static Project ToEntity(this ProjectDto projectDto, Project? project)
        {
            // Check if the project is null
            if (project is null)
            {
                throw new ArgumentNullException(nameof(projectDto), "Project entity cannot be null.");
            }

            // Call the private MapDtoToEntity method to perform the mapping
            return MapDtoToEntity(projectDto, project);
        }

        /// <summary>
        /// Extension method to convert a <see cref="Project"/> entity to a <see cref="ProjectDto"/>.
        /// </summary>
        /// <param name="project">The <see cref="Project"/> entity to convert.</param>
        /// <returns>The mapped <see cref="ProjectDto"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="project"/> is null.</exception>
        public static ProjectDto ToDto(this Project project)
        {
            // Check if the project is null
            if (project is null)
            {
                throw new ArgumentNullException(nameof(project), "Project entity cannot be null.");
            }

            // Call the private MapEntityToDto method to perform the mapping
            return MapEntityToDto(project);
        }
    }
}
