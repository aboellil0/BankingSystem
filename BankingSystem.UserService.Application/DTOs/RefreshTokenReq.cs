﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem.UserService.Application.DTOs
{
    public class RefreshTokenReq
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
