using MediatorProject.Core.IRepositories;
using MediatorProject.Models;

namespace MediatorProject.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private MediatorDataContext _appDbContext { get => _context as MediatorDataContext; }
        public UserRepository(MediatorDataContext context) : base(context)
        {
        }
    }
}
