using AutoMapperTest.Data;
using AutoMapperTest.Infrastractures;
using AutoMapperTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperTest.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) => _context = context;

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User Get(int? id) => _context.Users.FirstOrDefault(x => x.Id == id);

        public void Create(User item) => _context.Users.Add(item);

        public void Update(User item) => _context.Entry(item).State = EntityState.Modified;

        public void Delete(User user) => _context.Remove(user);

        public void Save() => _context.SaveChanges();

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
