using System.Threading.Tasks;
using Student.IdentityServer.Model;
using Student.IdentityServer.Model.Store;

namespace Student.IdentityServer.Pgsql.Store
{
    public class StudentStorePgSql : IStudentStore
    {


        public Task CreateAsync(StudentUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(StudentUser user)
        {
            throw new System.NotImplementedException();
        }

        public Task<StudentUser> FindByIdAsync(string userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<StudentUser> FindByNameAsync(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(StudentUser user)
        {
            throw new System.NotImplementedException();
        }

        public bool ValidateCredentials(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public StudentUser FindByUsername(string username)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            
        }
    }
}
