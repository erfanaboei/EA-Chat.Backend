using System.Runtime.CompilerServices;
using EA_Chat.Domain.Models;

namespace EA_Chat.Domain.Interfaces;

public interface IRepository<TEntity, TKey> where TEntity : class, IEntity
{
    #region Async Methods

    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity model, CancellationToken cancellationToken);
    Task<TEntity> UpdateAsync(TEntity model, CancellationToken cancellationToken);

    #endregion

    #region Methods

    List<TEntity> GetAll();
    TEntity? GetById(TKey id);
    TEntity Add(TEntity model);
    TEntity Update(TEntity model);

    #endregion
}