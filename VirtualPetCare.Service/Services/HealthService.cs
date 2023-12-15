using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Food;
using VirtualPetCare.Core.DTOs.Health;
using VirtualPetCare.Core.Models;
using VirtualPetCare.Core.Repositories;
using VirtualPetCare.Core.Services;
using VirtualPetCare.Core.UnitOfWorks;
using VirtualPetCare.Service.Exceptions;

namespace VirtualPetCare.Service.Services
{
    /// <summary>
    /// Represents a service for managing health information.
    /// </summary>
    public class HealthService : Service<Health>, IHealthService
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The health repository.</param>
        /// <param name="mapper">The mapper for mapping entities to DTOs.</param>
        public HealthService(IUnitOfWork unitOfWork, IGenericRepository<Health> repository, IMapper mapper) : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Applies the feeding effects of a specific food to the health of a pet.
        /// </summary>
        /// <param name="petId">Identifier of the pet to apply the feeding.</param>
        /// <param name="food">DTO representing the food to be applied.</param>
        /// <returns>Task representing the asynchronous operation.</returns>
        public async Task ApplyFeedToHealthAsync(int petId, FoodDto food)
        {
            var health = await _repository.GetAll().Include(x => x.Pet).Where(x => x.Pet.Id == petId).FirstOrDefaultAsync();
            if (health is null)
                throw new NotFoundException("Health Information not found");

            health.Status = health.Status != 100 ?
                health.Status += food.HealthEffect
                : health.Status;

            await _unitOfWork.CommitChangesAsync();


        }

        /// <summary>
        /// Gets health information by pet ID.
        /// </summary>
        /// <param name="petId">The ID of the pet.</param>
        /// <returns>Returns the health information as a DTO.</returns>
        /// <exception cref="NotFoundException">Thrown when the pet is not found.</exception>
        public async Task<HealthDto> GetByPetIdAsync(int petId)
        {
            var healthInformation = await _repository.GetAll().Include(x=> x.Pet).Where(x => x.Pet.Id == petId).FirstOrDefaultAsync();
            if (healthInformation is null)
                throw new NotFoundException("Pet not found");

            var healthDto = _mapper.Map<HealthDto>(healthInformation);

            return healthDto;
        }

        /// <summary>
        /// Updates health information with the provided DTO.
        /// </summary>
        /// <param name="petId">The ID of the pet.</param>
        /// <param name="entity">The DTO containing health information updates.</param>
        /// <exception cref="NotFoundException">Thrown when health information is not found.</exception>
        /// <exception cref="ClientSideException">Thrown when health status is out of the valid range.</exception>
        public async Task UpdateWithDtoAsync(int petId, HealthUpdateDto entity)
        {
            var health = await _repository.GetByIdAsync(petId);

            if (health is null)
                throw new NotFoundException("Health Information not found");
            if (entity.Status <=  0 || entity.Status > 100)
                throw new ClientSideException("Health Status can not be equal or less then 0 and greather then 100 ");

            health.Status = entity.Status;

            await _unitOfWork.CommitChangesAsync();
        }
    }
}
