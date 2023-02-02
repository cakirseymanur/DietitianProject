using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietitianProject.DtoLayer.DTOs.AppUserDTOs
{
    public class SignUpDto
    {
       public string UserName { get; set; }
       public string Password { get; set; }
       public string ConfirmPassword { get; set; }
       public string Gender { get; set; }
       public string Email { get; set; }
       public bool checkBox { get; set; }
    }
}
