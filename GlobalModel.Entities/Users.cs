﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalModel.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
