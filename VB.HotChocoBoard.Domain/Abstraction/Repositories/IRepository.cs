using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VB.HotChocoBoard.Domain.Abstraction.Entities;
using VB.HotChocoBoard.Domain.Abstraction.Results;

namespace VB.HotChocoBoard.Domain.Abstraction.Repositories;

public interface IRepository<TEntity> 
    where TEntity : Entity
{
    /// <summary>
    /// Gets the DbContext instance for database operations.
    /// </summary>
    DbContext DbContext { get; }

    /// <summary>
    /// Creates a new entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result indicating whether the operation was successful.</returns>
    Task<CustomResult<bool>> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result indicating whether the operation was successful.</returns>
    Task<CustomResult<bool>> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result indicating whether the operation was successful.</returns>
    Task<CustomResult<bool>> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result containing the entity if found, otherwise a failure result.</returns>
    Task<CustomResult<TEntity>> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if an entity exists based on the specified predicate.
    /// </summary>
    /// <param name="predicate">The predicate to evaluate.</param>
    /// <param name="cancellationToken">Cancellation token for the operation.</param>
    /// <returns>A result indicating whether an entity matching the predicate exists.</returns>
    Task<CustomResult<bool>> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
}
