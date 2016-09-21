using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using LacysMobile.Models;

namespace LacysMobile.Data
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(DbContext context)
            : base(context)
        {
        }

        public IQueryable<User> GetAllWithEntities()
        {
            return this._DbSet.Include(u => u.Roles);
        }
    }
}
