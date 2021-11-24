using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Student.IdentityServer.DI.Model;
using Student.IdentityServer.DI.Model.Store;

namespace Student.IdentityServer.Pgsql.Store
{
    public class StudentStorePgSql : IStudentStore
    {
        private readonly AuthDbContext context;

        StudentStorePgSql(AuthDbContext pContext)
        {
            context = pContext;
        }

        public bool ValidateCredentials(string username, string password)
        {
            throw new NotImplementedException();
        }

        public StudentUser FindByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public StudentUser FindByExternalProvider(string provider, string providerUserId)
        {
            throw new NotImplementedException();
        }

        public StudentUser AutoProvisionUser(string provider, string providerUserId, List<Claim> claims)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<IdentityResult> CreateAsync(StudentUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await using (context)
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                context.Add(user);
                await context.SaveChangesAsync(cancellationToken);
            }
            return IdentityResult.Success;
        }

        public async Task<IdentityResult> DeleteAsync(StudentUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await using (context)
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                context.Remove(user);
                await context.SaveChangesAsync(cancellationToken);
            }
            return IdentityResult.Success;
        }

        public async Task<StudentUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Guid id;
            if (!Guid.TryParse(userId, out id))
            {
                throw new ArgumentException("Id was not a valid Guid: " + userId, nameof(userId));
            }
            
            await using (context)
            {
                return await context.FindAsync<StudentUser>(userId);
            }

        }

        public async Task<StudentUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await using (context)
            {
                return context.StudentSet.FirstOrDefault(x => string.Equals(normalizedUserName, x.NormalizedUserName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public Task<string> GetNormalizedUserNameAsync(StudentUser user, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.NormalizedUserName);
        }

        public Task<string> GetUserIdAsync(StudentUser user, CancellationToken cancellationToken)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return Task.FromResult(user.Id);
        }

        public Task<string> GetUserNameAsync(StudentUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedUserNameAsync(StudentUser user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetUserNameAsync(StudentUser user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> UpdateAsync(StudentUser user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            await using (context)
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                context.Update(user);
                await context.SaveChangesAsync(cancellationToken);
            }
            return IdentityResult.Success;
        }
    }
}
