using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagementSystem.BAL
{
     public class Designation
    {
         [Key]
         public int DesignationId { set; get; }

     public string DesignationName { set; get; }
    }
}
