using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Models;
using VirtualPetCare.Core.Repositories;
using VirtualPetCare.Core.Services;
using VirtualPetCare.Core.UnitOfWorks;

namespace VirtualPetCare.Service.Services
{
    /// <summary>
    /// Base service class for managing entities.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public class Service<T> : IService<T> where T : BaseModel
    {
        protected readonly IGenericRepository<T> _repository;
        protected readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="Service{T}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The generic repository for the entity.</param>
        public Service(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        /// <summary>
        /// Adds a new entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>Returns the added entity.</returns>
        public async Task<T> AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitChangesAsync();

            return entity;
        }

        /// <summary>
        /// Adds a collection of entities to the repository.
        /// </summary>
        /// <param name="items">The collection of entities to be added.</param>
        /// <returns>Returns the added entities.</returns>
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> items)
        {
            await _repository.AddRangeAsync(items);
            await _unitOfWork.CommitChangesAsync();

            return items;
        }

        /// <summary>
        /// Checks if there is any entity satisfying the given condition.
        /// </summary>
        /// <param name="expression">The condition to check.</param>
        /// <returns>Returns true if any entity satisfies the condition; otherwise, false.</returns>
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        /// <summary>
        /// Gets all entities from the repository.
        /// </summary>
        /// <returns>Returns a collection of all entities.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        /// <summary>
        /// Gets an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>Returns the entity with the specified ID.</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            var hasData = await _repository.GetByIdAsync(id);

            return hasData;
        }

        /// <summary>
        /// Removes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to remove.</param>
        public async Task RemoveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            _repository.Remove(entity);
            await _unitOfWork.CommitChangesAsync();
        }

        /// <summary>
        /// Removes a collection of entities from the repository.
        /// </summary>
        /// <param name="items">The collection of entities to be removed.</param>
        public async Task RemoveRangeAsync(IEnumerable<T> items)
        {
            _repository.RemoveRange(items);
            await _unitOfWork.CommitChangesAsync();
        }

        /// <summary>
        /// Updates an entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        public async Task UpdateAsync(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitChangesAsync();
        }

        /// <summary>
        /// Filters entities based on the provided condition.
        /// </summary>
        /// <param name="expression">The condition to filter entities.</param>
        /// <returns>Returns a filtered collection of entities.</returns>
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
