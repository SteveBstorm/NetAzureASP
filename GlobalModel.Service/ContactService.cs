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
    public class ContactService : IContactService
    {
        private string _connectionString;

        public ContactService(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("MyConnection");
        }

        public Contact Convert(IDataRecord reader)
        {
            return new Contact
            {
                Id = (int)reader["Id"],
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                Email = reader["Email"].ToString(),
                IsFavorite = (bool)reader["IsFavorite"]
            };
        }

        #region GetAll() ADO
        //GetAll() avec ADO complet
        //public IEnumerable<Contact> GetAll()
        //{
        //    using (SqlConnection connection = new SqlConnection(_connectionString))
        //    {
        //        using (SqlCommand cmd = connection.CreateCommand())
        //        {
        //            connection.Open();
        //            cmd.CommandText = "SELECT * FROM V_Contact";

        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    yield return new Contact
        //                    {
        //                        Id = (int)reader["Id"],
        //                        LastName = reader["LastName"].ToString(),
        //                        FirstName = reader["FirstName"].ToString(),
        //                        Email = reader["Email"].ToString(),
        //                        IsFavorite = (bool)reader["IsFavorite"]
        //                    };
        //                }
        //            }

        //            connection.Close();
        //        }
        //    }

        //} 
        #endregion

        public IEnumerable<Contact> GetAll()
        {
            Connection connection = new Connection(SqlClientFactory.Instance, _connectionString);
            string query = "SELECT * FROM V_Contact";
            Command cmd = new Command(query);

            return connection.ExecuteReader<Contact>(cmd, Convert);
        }

        public Contact GetById(int Id)
        {
            Contact c = new Contact();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "SELECT * FROM V_Contact WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", Id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            c.Id = (int)reader["Id"];
                            c.LastName = reader["LastName"].ToString();
                            c.FirstName = reader["FirstName"].ToString();
                            c.Email = reader["Email"].ToString();
                            c.IsFavorite = (bool)reader["IsFavorite"];
                        }
                    }

                    connection.Close();
                }
            }
            return c;
        }

        public int Create(Contact c)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "ContactCreate";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("FirstName", c.FirstName);
                    cmd.Parameters.AddWithValue("LastName", c.LastName);
                    cmd.Parameters.AddWithValue("Email", c.Email);
                    cmd.Parameters.AddWithValue("IsFavorite", c.IsFavorite);



                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public void Update(Contact c)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "ContactUpdate";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("FirstName", c.FirstName);
                    cmd.Parameters.AddWithValue("LastName", c.LastName);
                    cmd.Parameters.AddWithValue("Email", c.Email);
                    cmd.Parameters.AddWithValue("IsFavorite", c.IsFavorite);
                    cmd.Parameters.AddWithValue("Id", c.Id);


                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = "ContactDelete";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Id", Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
