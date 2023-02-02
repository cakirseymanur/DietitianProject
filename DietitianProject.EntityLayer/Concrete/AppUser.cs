﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Gender { get; set; }
        public string MailCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageURL { get; set; }
    }
}
