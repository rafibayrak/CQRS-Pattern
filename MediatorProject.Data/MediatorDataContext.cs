﻿
using MediatorProject.Core.IRepositories;
using MediatorProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorProject.Data
{
    public class MediatorDataContext : DbContext, IMediatorDataContext
    {
        public MediatorDataContext(DbContextOptions<MediatorDataContext> options) : base(options)
        {
        }

        public DbContext DbContext { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
