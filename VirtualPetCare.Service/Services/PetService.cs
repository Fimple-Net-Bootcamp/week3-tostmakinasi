using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Core.DTOs.User;
using VirtualPetCare.Core.Models;
using VirtualPetCare.Core.Repositories;
using VirtualPetCare.Core.Services;
using VirtualPetCare.Core.UnitOfWorks;
using VirtualPetCare.Service.Exceptions;

namespace VirtualPetCare.Service.Services
{
    /// <summary>
    /// Service class providing operations related to pets.
    /// </summary>
    public class PetService : IPetService
    {
        private readonly IPetRepository _repository;
        private readonly IGenericRepository<Health> _healthRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PetService"/> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of work for managing database transactions.</param>
        /// <param name="repository">Repository for pet-related database operations.</param>
        /// <param name="mapper">Mapper for object-to-object mapping.</param>
        /// <param name="healthRepository">Repository for health-related database operations.</param>
        public PetService(IUnitOfWork unitOfWork, IPetRepository repository, IMapper mapper, IGenericRepository<Health> healthRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _healthRepository = healthRepository;
        }

        /// <inheritdoc/>
        public async Task<PetDto> CreateAsync(PetCreateDto entity)
        {
            await _unitOfWork.BeginTransactionAsync();

            var checkPet = await _repository
                .Where(x => x.OwnerId == entity.OwnerId && x.PetSpeciesId == entity.PetSpeciesId && x.PetName == entity.PetName)
                .AnyAsync();

            if (checkPet)
                throw new ClientSideException("User already owns this pet");

            var newPet = _mapper.Map<Pet>(entity);

            var health = new Health
            {
                IsAlive = true,
                Status = 100,
            };
            newPet.Health = health;

            await _repository.AddAsync(newPet);
            await _unitOfWork.TransactionCommitAsync();
            var petDto = _mapper.Map<PetDto>(newPet);

            return petDto ;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PetListDto>> GetAllAsync()
        {
            var pets = await _repository.GetAllWithRelation();

            if (!pets.Any())
                throw new NotFoundException("Pets not found.");

            var petDtos = _mapper.Map<List<PetListDto>>(pets);

            return petDtos;
        }

        /// <inheritdoc/>
        public async Task<PetDto> GetByIdAsync(int id)
        {
            var pet = await _repository.GetByIdWithOwnerAsync(id);

            if (pet == null)
                throw new NotFoundException($"Pet({id}) not found.");

            var petDto = _mapper.Map<PetDto>(pet);

            return petDto;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<PetListDto>> GetByOwnerIdAsync(int ownerId)
        {
            var pets = await _repository.Where(x => x.OwnerId == ownerId).Include(x=> x.PetSpecies).ToListAsync();

            if (!pets.Any())
                throw new NotFoundException("Pets not found.");
            var petDtos = _mapper.Map<IEnumerable<PetListDto>>(pets);
            return petDtos;
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(int id, PetUpdateDto entity)
        {
            var pet = await _repository.GetByIdAsync(id);

            if (pet == null)
                throw new NotFoundException($"Pet({id}) not found.");

            pet.PetName = entity.PetName != default ? entity.PetName : pet.PetName;

            await _unitOfWork.CommitChangesAsync();
        }
    }

}
