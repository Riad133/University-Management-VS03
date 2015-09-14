using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem.BAL
{
     public class Designation
    {

        public int DesignationId { set; get; }

         [DisplayName("Designation")]
        public string DesignationName { set; get; }
    }
}
