using GestContact.Abstractions;
using GestContact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestContact.Services
{
    public class FakeContactService: IContactService
    {
        private readonly List<Contact> contacts= new List<Contact>();

        private int currentId = 0;

        public void AddContact(Contact newContact)
        {
            newContact.Id = ++currentId;
            contacts.Add(newContact);
        }

        public List<Contact> GetAll()
        {
            return contacts;
        }

        public Contact GetContact(int id)
        {
            return contacts.Where(c => c.Id == id).First();
        }

        public void RemoveContact(int id)
        {
            contacts.Remove(GetContact(id));
        }

        public void UpdateContact(Contact newValues)
        {
            Contact oldValues = GetContact(newValues.Id);
            oldValues.LastName = newValues.LastName;
            oldValues.FirstName = newValues.FirstName;
            oldValues.IsFavorite = newValues.IsFavorite;
            oldValues.Email = newValues.Email;
        }
    }
}
