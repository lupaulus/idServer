using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Student.IdentityServer.Model;
using Student.IdentityServer.Model.Store;

namespace Student.IdentityServer.Pgsql.Store
{
    public class StudentStorePgSql : IStudentStore
    {


        public bool ValidateCredentials(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public StudentUser FindByUsername(string username)
        {
            throw new System.NotImplementedException();
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
            
        }

        public Task<IdentityResult> CreateAsync(StudentUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(StudentUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StudentUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StudentUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(StudentUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(StudentUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

        public Task<IdentityResult> UpdateAsync(StudentUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
