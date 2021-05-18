using AutoMapperTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapperTest.ViewModels;

namespace AutoMapperTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        public DbSet<AutoMapperTest.ViewModels.IndexUserViewModel> IndexUserViewModel { get; set; }

        public DbSet<AutoMapperTest.ViewModels.CreateUserViewModel> CreateUserViewModel { get; set; }

        public DbSet<AutoMapperTest.ViewModels.DeleteUserViewModel> DeleteUserViewModel { get; set; }

        public DbSet<AutoMapperTest.ViewModels.EditUserViewModel> EditUserViewModel { get; set; }
    }
}
