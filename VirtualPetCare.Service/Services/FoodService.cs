using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Food;
using VirtualPetCare.Core.Models;
using VirtualPetCare.Core.Repositories;
using VirtualPetCare.Core.Services;
using VirtualPetCare.Core.UnitOfWorks;

namespace VirtualPetCare.Service.Services
{
    /// <summary>
    /// Service class for managing food-related operations.
    /// </summary>
    public class FoodService : Service<Food>, IFoodService
    {
        private readonly IMapper _mapper;
        private readonly IHealthService _healthService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository for food entities.</param>
        /// <param name="mapper">The mapper for DTO transformations.</param>
        public FoodService(IUnitOfWork unitOfWork, IGenericRepository<Food> repository, IMapper mapper, IHealthService healthService) : base(unitOfWork, repository)
        {
            _mapper = mapper;
            _healthService = healthService;
        }

        /// <inheritdoc/>
        public async Task FeedPetById(int petId, FoodFeedingDto fooddto)
        {
            _unitOfWork.BeginTransactionAsync();

            var food = await _repository.GetByIdAsync(fooddto.FoodId);

            var foodDto = _mapper.Map<FoodDto>(fooddto);

            await _healthService.ApplyFeedToHealthAsync(petId, foodDto);

            food.FoodHistories.Add(new()
            {
                FoodId = food.Id,
                PetId = petId,
                HealthEffect = food.HealthEffect,
            });

            await _unitOfWork.TransactionCommitAsync();
            
        }

        /// <inheritdoc/>
        public async Task<List<FoodDto>> GetAllWithDto()
        {
            var foods = await _repository.GetAll().ToListAsync();

            var foodDtos = _mapper.Map<List<FoodDto>>(foods);

            return foodDtos;
        }
    }
}
