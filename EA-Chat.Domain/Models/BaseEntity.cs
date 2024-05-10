using System.ComponentModel.DataAnnotations;

namespace EA_Chat.Domain.Models;

public interface IEntity
{
    
}

public class BaseEntity<TKey>: IEntity
{
    [Key]
    public TKey Id { get; set; }
}

public class BaseEntity : BaseEntity<int>
{
    
}

