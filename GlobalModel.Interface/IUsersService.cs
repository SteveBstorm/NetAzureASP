using GlobalModel.Entities;
using System.Collections.Generic;
using System.Data;

namespace GlobalModel.Interface
{
    public interface IUsersService
    {
        Users Convert(IDataReader reader);
        IEnumerable<Users> GetAll();
        Users GetById(int Id);
        Users Login(string email, string password);
        void Register(Users u);
    }
}