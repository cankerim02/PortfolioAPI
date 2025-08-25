using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class UserAddDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Admin" veya "User" olabilir
    }

}
