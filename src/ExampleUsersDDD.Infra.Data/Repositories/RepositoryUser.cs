
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using ExampleUsersDDD.Domain.Entities;
using ExampleUsersDDD.Domain.Enums;
using ExampleUsersDDD.Domain.Interfaces.Repositories;

using ExampleUsersDDD.Infra.Data.Context;

namespace ExampleUsersDDD.Infra.Data.Repositories
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser(DbContextBase dbContext) : base(dbContext)
        {
            
        }

        // Customizations:
        public async Task<User> GetByEmail(string email)
        {
            var user = await this.dbSet.AsNoTracking()
                                       .FirstOrDefaultAsync(entity => entity.Email == email)
                                       .ConfigureAwait(false);
            return user;
        }

        public async Task<IList<User>> GetAllByStatus(AccountStatusEnum status)
        {
            var users = await this.dbSet.Where(user => user.Status == status)
                                        .ToListAsync()
                                        .ConfigureAwait(false);
            return users;
        }

        // Override:
        public override async Task Remove(User user)
        {
            if (user == null) 
                throw new ArgumentNullException(nameof(user));

            // const string deleteSQL = @"
            //     DELETE FROM Account WHERE Id = @Id;
            //     DELETE FROM Users WHERE Id = @Id;
            // ";
            const string deleteSQL = @"
                DELETE FROM Users WHERE Id = @Id;
            ";

            var id = new SqlParameter("@Id", user.Id);

            await this.dbContext.Database.ExecuteSqlRawAsync(deleteSQL, id).ConfigureAwait(false);
        }

    }
}
