using Riok.Mapperly.Abstractions;
using ProjectManagement.Dto;
using ProjectManagement.Models;


namespace ProjectManagement.Mappers
{
    [Mapper]
    [UseStaticMapper(typeof(SubTaskMapper))]
    public static partial class Mapper 
    {
        // Projects
        public static partial ProjectDto ToDto(this Project project);
        public static partial void ToEntity(this ProjectDto projectDto, Project project);

        //Statuses
        public static partial StatusDto ToDto(this Status status);
        public static partial void ToEntity(this StatusDto statusDto, Status status);

        //Tasks
        public static partial ProjectTaskDto ToDto(this ProjectTask projectTask);
        public static partial void ToEntity(this ProjectTaskDto projectTaskDto, ProjectTask projectTask);
    }
}
