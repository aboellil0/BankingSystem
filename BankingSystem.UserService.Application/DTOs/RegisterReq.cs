﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Application.DTOs
{
    public class RegisterReq
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateOnly Birthaday { get; set; }
        public string IpAddress { get; set; }
    }
}
