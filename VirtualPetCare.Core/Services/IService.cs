using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Core.Models;

namespace VirtualPetCare.Core.Services
{
    /// <summary>
    /// General service interface containing CRUD (Create, Read, Update, Delete) operations.
    /// </summary>
    /// <typeparam name="T">Type of the object being operated on.</typeparam>
    public interface IService<T> where T : class
    {
        /// <summary>
        /// Asynchronously retrieves the object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the object to retrieve.</param>
        /// <returns>Object with the specified ID.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves all objects.
        /// </summary>
        /// <returns>Collection of all objects.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Retrieves objects based on the specified condition.
        /// </summary>
        /// <param name="expression">Condition expression.</param>
        /// <returns>Query for objects that satisfy the condition.</returns>
        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Checks if there is any object that satisfies the specified condition.
        /// </summary>
        /// <param name="expression">Condition expression.</param>
        /// <returns>Boolean indicating whether any object satisfies the condition.</returns>
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Asynchronously adds a collection of objects.
        /// </summary>
        /// <param name="items">Collection of objects to be added.</param>
        /// <returns>Added collection after the operation.</returns>
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> items);

        /// <summary>
        /// Asynchronously adds a collection of objects.
        /// </summary>
        /// <param name="items">Collection of objects to be added.</param>
        /// <returns>Added collection after the operation.</returns>
        Task<T> AddAsync(T entity);

        /// <summary>
        /// Asynchronously updates an object.
        /// </summary>
        /// <param name="entity">Object to be updated.</param>
        Task UpdateAsync(T entity);

        // <summary>
        /// Asynchronously removes an object with the specified ID.
        /// </summary>
        /// <param name="id">ID of the object to be removed.</param>
        Task RemoveAsync(int id);

        /// <summary>
        /// Asynchronously removes objects in the specified collection.
        /// </summary>
        /// <param name="items">Collection of objects to be removed.</param>
        Task RemoveRangeAsync(IEnumerable<T> items);
    }
}
