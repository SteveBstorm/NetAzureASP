using ADOLibrary;
using GlobalModel.Entities;
using GlobalModel.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalModel.Service
{
    public class UsersService : IUsersService
    {
        private string _connectionString;

        public UsersService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MyConnection");
        }

        public Users Convert(IDataReader reader)
        {
            return new Users
            {
                Id = (int)reader["Id"],
                Email = reader["Email"].ToString(),
                
                IsAdmin = (bool)reader["IsAdmin"]
            };
        }

        public Users Login(string email, string password)
        {
            Connection c = new Connection(SqlClientFactory.Instance, _connectionString);
            Command cmd = new Command("LoginUser", true);

            cmd.AddParameter("Email", email);
            cmd.AddParameter("Password", password);

            return c.ExecuteReader<Users>(cmd, Convert).FirstOrDefault();
        }

        public void Register(Users u)
        {
            Connection c = new Connection(SqlClientFactory.Instance, _connectionString);
            Command cmd = new Command("RegisterUser", true);
            cmd.AddParameter("Email", u.Email);
            cmd.AddParameter("Password", u.Password);

            c.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Users> GetAll()
        {
            Connection c = new Connection(SqlClientFactory.Instance, _connectionString);
            Command cmd = new Command("SELECT * FROM V_Users");

            return c.ExecuteReader<Users>(cmd, Convert);
        }

        public Users GetById(int Id)
        {
            Connection c = new Connection(SqlClientFactory.Instance, _connectionString);
            Command cmd = new Command("SELECT * FROM V_Users WHERE Id = @Id");
            cmd.AddParameter("Id", Id);

            return c.ExecuteReader<Users>(cmd, Convert).FirstOrDefault();
        }
    }
}
