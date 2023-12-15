using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.User;
using VirtualPetCare.Core.Models;
using VirtualPetCare.Core.Repositories;
using VirtualPetCare.Core.Services;
using VirtualPetCare.Core.UnitOfWorks;
using VirtualPetCare.Repository.Repositories;
using VirtualPetCare.Service.Exceptions;

namespace VirtualPetCare.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<UserDto> CreateAsync(UserCreateDto entity)
        {
            var check = await _repository.AnyAsync(x => x.UserName == entity.UserName);
            if (check)
                throw new ClientSideException($"User({entity.UserName}) already exists");
            var user = _mapper.Map<User>(entity);

            await _repository.AddAsync(user);
            await _unitOfWork.CommitChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UserListDto>> GetAllAsync()
        {
            var users = await _repository.GetAll().ToListAsync();

            if (!users.Any())
                throw new NotFoundException("Users not found.");

            var userDtos = _mapper.Map<List<UserListDto>>(users);

            return userDtos;
        }

        /// <inheritdoc/>
        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdWithOwnershipsAsync(id);

            if(user == null)
                throw new NotFoundException($"User({id}) not found.");

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        /// <inheritdoc/>
        public async Task RemoveAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                throw new NotFoundException($"User({id}) not found.");

            user.IsActive = false;
            user.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.CommitChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(int id, UserUpdateDto entity)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                throw new NotFoundException($"User({id}) not found.");

            user.FirstName = entity.FirstName != default ? entity.FirstName : user.FirstName;
            user.LastName = entity.LastName != default ? entity.LastName : user.LastName;
            user.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.CommitChangesAsync();
        }
    }
}
