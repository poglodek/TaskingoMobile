using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskingoMobile.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string PasswordHashed { get; set; }
    }
}
