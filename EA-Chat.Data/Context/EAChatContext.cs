using EA_Chat.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace EA_Chat.Data.Context;

public class EAChatContext:DbContext
{
    #region Constractor

    public EAChatContext(DbContextOptions<EAChatContext> options):base(options)
    {
        
    }

    #endregion

    #region Users

    public DbSet<User> Users { get; set; }

    #endregion
}