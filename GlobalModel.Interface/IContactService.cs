using GlobalModel.Entities;
using System.Collections.Generic;

namespace GlobalModel.Interface
{
    public interface IContactService
    {
        int Create(Contact c);
        void Delete(int Id);
        IEnumerable<Contact> GetAll();
        Contact GetById(int Id);
        void Update(Contact c);
    }
}