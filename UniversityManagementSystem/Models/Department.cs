using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UniversityManagementSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "You Must Fill Department Code Field")]
        [Index(IsUnique = true)]
        [MaxLength(32)]
        [StringLength(7, ErrorMessage = "The {0} must be at least {2} characters long and less then 8 characters.", MinimumLength = 2)]
        [Remote("DoesCodeNameExist", "Departments", HttpMethod = "POST", ErrorMessage = "Department Code exist")]

        public string DepartmentCode { get; set; }


        [Required(ErrorMessage = "You Must Fill Department Name Field")]
        [Index(IsUnique = true)]
        [MaxLength(32)]
        public string DepartmentName { get; set; }
        public virtual List<Course> Courses { set; get; } 
    }
}
