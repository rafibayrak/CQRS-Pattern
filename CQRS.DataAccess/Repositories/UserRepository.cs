using CQRS.DataAccess.IRepositories;
using CQRS.Data.Models;
using CQRS.Data;

namespace CQRS.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private MediatorDataContext _appDbContext { get => _context as MediatorDataContext; }
        public UserRepository(MediatorDataContext context) : base(context)
        {
        }
    }
}
