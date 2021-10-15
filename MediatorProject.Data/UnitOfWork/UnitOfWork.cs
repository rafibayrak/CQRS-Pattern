using MediatorProject.Core.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MediatorDataContext _context;
        public UnitOfWork(MediatorDataContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
