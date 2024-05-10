using EA_Chat.Data.Context;
using EA_Chat.Domain.Interfaces;
using EA_Chat.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EA_Chat.Data.Repositories;

public class Repository<TEntity, TKey>: IRepository<TEntity, TKey> where TEntity : class, IEntity
{
    private readonly EAChatContext _context;
    private readonly DbSet<TEntity> _entity;
    
    public Repository(EAChatContext context)
    {
        _context = context;
        _entity = _context.Set<TEntity>();
    }
    
    #region Async Methods

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _entity.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken)
    {
        return await _entity.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity model, CancellationToken cancellationToken)
    {
        try
        {
            await _entity.AddAsync(model, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return model;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<TEntity> UpdateAsync(TEntity model, CancellationToken cancellationToken)
    {
        try
        {
            _entity.Update(model);
            await _context.SaveChangesAsync(cancellationToken);
            return model;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Methods

    public List<TEntity> GetAll()
    {
        return _entity.ToList();
    }

    public TEntity? GetById(TKey id)
    {
        return _entity.Find(id);
    }

    public TEntity Add(TEntity model)
    {
        try
        {
            _entity.Add(model);
            _context.SaveChanges();
            return model;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public TEntity Update(TEntity model)
    {
        try
        {
            _entity.Update(model);
            _context.SaveChanges();
            return model;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}