using MediatorProject.Core.IRepositories;
using MediatorProject.Core.IServices;
using MediatorProject.Core.IUnitOfWorks;
using MediatorProject.Models;

namespace MediatorProject.Data.Services
{
    public class UserService : RepositoryService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {
        }

    }
}
