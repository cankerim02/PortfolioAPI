using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }

        // // ilk etapta düz, sonra hash yapılır
        public string Password { get; set; }
        //admin- user ayrımı rolü için
        public string Role { get; set; }
    }
}
