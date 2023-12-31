﻿using PaperFineryApp_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperFineryApp_Domain.Dtos.RequestDto
{
    public class RegisterRequestDto
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }    
        public UserType UserType { get; set; }  
    }
}
