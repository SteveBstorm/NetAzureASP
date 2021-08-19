using GestContact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Abstractions
{
    public interface IContactService
    {
        List<Contact> GetAll();
        void AddContact(Contact newContact);
        void RemoveContact(int id);
        void UpdateContact(Contact newValues);
        Contact GetContact(int id); 
    }
}
