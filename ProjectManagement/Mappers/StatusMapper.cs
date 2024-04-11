using ProjectManagement.Dto;
using ProjectManagement.Models;
using System;

namespace ProjectManagement.Mappers
{
    /// <summary>
    /// Provides methods to map between <see cref="Status"/> entity and <see cref="StatusDto"/> DTO.
    /// </summary>
    public static partial class StatusMapper 
    {
        /// <summary>
        /// Maps a <see cref="Status"/> entity to a <see cref="StatusDto"/>.
        /// </summary>
        /// <param name="status">The <see cref="Status"/> entity to map.</param>
        /// <returns>The mapped <see cref="StatusDto"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="status"/> is null.</exception>
        private static StatusDto MapEntityToDto(Status status)
        {
            // Check if the status is null
            if (status is null) 
            {
                throw new NullReferenceException("Status is null.");
            } 

            // Map the properties of the Status entity to the corresponding properties of StatusDto
            return new StatusDto
            {
                Id = status.Id,
                Name = status.Name,
            };
        }

        /// <summary>
        /// Maps a <see cref="StatusDto"/> to a <see cref="Status"/> entity.
        /// </summary>
        /// <param name="statusDto">The <see cref="StatusDto"/> to map.</param>
        /// <param name="status">The target <see cref="Status"/> entity to map to.</param>
        /// <returns>The mapped <see cref="Status"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either the <paramref name="status"/> or <paramref name="statusDto"/> is null.</exception>
        private static Status MapDtoToEntity(StatusDto statusDto, Status status)
        {
            // Check if the status or statusDto is null
            if (statusDto is null) 
            {
                throw new NullReferenceException("Status is null.");
            } 
            
            // Maps the properties of StatusDto to the corresponding properties of the Status entity
            status.Id = statusDto.Id;
            status.Name = statusDto.Name;

            return status;
        }

        /// <summary>
        /// Extension method to convert a <see cref="StatusDto"/> to a <see cref="Status"/> entity.
        /// </summary>
        /// <param name="statusDto">The <see cref="StatusDto"/> to convert.</param>
        /// <param name="status">The target <see cref="Status"/> entity to map to.</param>
        /// <returns>The mapped <see cref="Status"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="status"/> is null.</exception>
        public static Status ToEntity(this StatusDto statusDto, Status? status)
        {
            ArgumentNullException.ThrowIfNull(status);

            // Calls the MapDtoToEntity method to perform the mapping
            return MapDtoToEntity(statusDto, status);
        }

        /// <summary>
        /// Extension method to convert a <see cref="Status"/> entity to a <see cref="StatusDto"/>.
        /// </summary>
        /// <param name="status">The <see cref="Status"/> entity to convert.</param>
        /// <returns>The mapped <see cref="StatusDto"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="status"/> is null.</exception>
        public static StatusDto ToDto(this Status status)
        {
            // Check if the status is null
            if (status is null)
            {
                throw new ArgumentNullException(nameof(status), "Status entity cannot be null.");
            }

            // Calls the private MapEntityToDto method to perform the mapping
            return MapEntityToDto(status);
        }
    }
}
