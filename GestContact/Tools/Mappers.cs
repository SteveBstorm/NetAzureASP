using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL = GlobalModel.Entities;
using ASP = GestContact.Models;

namespace GestContact.Tools
{
    public static class Mappers
    {
        public static DAL.Contact ToDal(this ASP.Contact c)
        {
            return new DAL.Contact
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                IsFavorite = c.IsFavorite
            };
        }

        public static ASP.Contact ToASP(this DAL.Contact c)
        {
            return new ASP.Contact
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                IsFavorite = c.IsFavorite
            };
        }

        public static ASP.User ToASP(this DAL.Users u)
        {
            return new ASP.User
            {
                Id = u.Id,
                Email = u.Email,
                IsAdmin = u.IsAdmin
            };
        }

        public static DAL.Users ToDal(this ASP.RegisterForm form)
        {
            return new DAL.Users
            {
                Email = form.Email,
                Password = form.Password
            };
        }
    }
}
