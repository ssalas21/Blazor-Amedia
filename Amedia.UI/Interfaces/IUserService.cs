using Amedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amedia.UI.Interfaces {
    public interface IUserService {
        Task<int> GetUser(string user, string pass);
        Task<IEnumerable<tUser>> GetAllUsers();
        Task<bool> InsertUser(tUser user);
        Task<bool> UpdateUser(tUser user);
        Task<bool> DeleteUser(tUser user);
        Task<tUser> GetUserDetails(int id);
    }
}
