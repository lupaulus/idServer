using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Student.IdentityServer.DI.Model.Store
{
    public interface IStudentStore : IUserStore<StudentUser>
    {
        bool ValidateCredentials(string username, string password);
        StudentUser FindByUsername(string username);
        StudentUser FindByExternalProvider(string provider, string providerUserId);
        StudentUser AutoProvisionUser(string provider, string providerUserId, List<Claim> claims);
    }
}
