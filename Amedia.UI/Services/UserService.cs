using Amedia.UI.Data;
using Amedia.Data.Dapper.Repositories;
using Amedia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amedia.UI.Interfaces;

namespace Amedia.UI.Services {
    public class UserService : IUserService{

        private readonly SqlConfiguration _configuration;

        private IUserRepository _userrepository;

        public UserService(SqlConfiguration configuration) {
            _configuration = configuration;
            _userrepository = new UserRepository(configuration.ConnectionString);
        }

        public Task<int> GetUser(string user, string pass) {
            return _userrepository.GetUser(user, pass);
        }

        public Task<bool> InsertUser(tUser user) {
            return _userrepository.InsertUser(user);
        }

        public Task<IEnumerable<tUser>> GetAllUsers() {
            return _userrepository.GetAllUsers();
        }

        public Task<bool> UpdateUser(tUser user) {
            return _userrepository.UpdateUser(user);
        }
        public Task<bool> DeleteUser(tUser user) {
            return _userrepository.DeleteUser(user);
        }
        public Task<tUser> GetUserDetails(int id) {
            return _userrepository.GetUserDetails(id);
        }


    }
}
