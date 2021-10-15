using MediatorProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorProject.Core.IRepositories
{
    public interface IMediatorDataContext
    {
        DbContext DbContext { get; set; }
        DbSet<User> Users { get; set; }
    }
}
