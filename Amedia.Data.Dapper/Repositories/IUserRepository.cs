using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amedia.Model;

namespace Amedia.Data.Dapper.Repositories {
    public interface IUserRepository {

        Task<int> GetUser(string user, string pass);

        Task<IEnumerable<tUser>> GetAllUsers();

        Task<bool> InsertUser(tUser user);

        Task<bool> UpdateUser(tUser user);

        Task<bool> DeleteUser(tUser user);

        Task<tUser> GetUserDetails(int id);


    }
}
