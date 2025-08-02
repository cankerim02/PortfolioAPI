using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
   
    public class DashboardDto
    {
        public int TotalProjects { get; set; }
        public int TotalMessages { get; set; }
        public int RepliedMessages { get; set; }
    }

}
