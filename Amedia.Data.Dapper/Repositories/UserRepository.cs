using Amedia.Model;
using Dapper;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Amedia.Data.Dapper.Repositories {
    public class UserRepository : IUserRepository {

        private string ConnectionString;

        public UserRepository(string connectionString) {
            ConnectionString = connectionString;
        }

        protected SqlConnection dbConnection() {
            return new SqlConnection(ConnectionString);
        }

        public async Task<bool> DeleteUser(tUser user) {
            var db = dbConnection();
            var sql = @"EXEC [spObtenerUsuarios] @Id";
            var result = await db.ExecuteAsync(sql.ToString(), new { Id = user.cod_usuario}).ConfigureAwait(false);
            return result > 0;
        }

        public async Task<IEnumerable<tUser>> GetAllUsers() {
            var db = dbConnection();
            var sql = @"EXEC [spObtenerUsuarios]";
            IEnumerable<tUser> aux = await db.QueryAsync<tUser>(sql.ToString(), new { }).ConfigureAwait(false);
            return aux;
        }

        public async Task<int> GetUser(string user, string pass) {
            var db = dbConnection();
            var sql = @"EXEC [spValidarLogin] @User, @Pass;";
            return await db.QuerySingleOrDefaultAsync<int>(sql.ToString(), new { User = user, Pass = pass }).ConfigureAwait(false);
        }

        public async Task<bool> InsertUser(tUser user) {
            user.cod_rol = 2;
            var db = dbConnection();
            var sql = @"EXEC [spAgregaUsuario] @User, @Password, @Nombre, @Apellido, @Documento, @Rol, '';";
            var result = await db.ExecuteAsync(sql.ToString(), new { User = user.txt_user, Password = user.txt_password, Nombre = user.txt_nombre, Apellido = user.txt_apellido, Documento = user.nro_doc, Rol = user.cod_rol }).ConfigureAwait(false);
            if (result.ToString().Equals("El documento ya se encuentra registrado")) return false;
            else return true;
        }

        public async Task<bool> UpdateUser(tUser user) {
            var db = dbConnection();
            var sql = @"EXEC [spActualizarUsuario] @Id, @User, @Password, @Nombre, @Apellido, @Documento, @Rol, @Activo;";
            var result = await db.ExecuteAsync(sql.ToString(), new {Id = user.cod_usuario, User = user.txt_user, Password = user.txt_password, Nombre = user.txt_nombre, Apellido = user.txt_apellido, Documento = user.nro_doc, Rol = user.cod_rol, Activo = user.sn_activo }).ConfigureAwait(false);
            return result > 0;
        }
        public async Task<tUser> GetUserDetails(int id) {
            var db = dbConnection();
            var sql = @"EXEC [spDetalleUsuario] @Id";
            return await db.QueryFirstOrDefaultAsync<tUser>(sql.ToString(), new { Id = id });
        }

    }
}
