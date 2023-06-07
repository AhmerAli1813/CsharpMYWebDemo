using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AhmerMYWebDemo.Models
{
    public class Departments
    {
        [Key]
        public int Dep_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Dep_Name { get; set; }
        
        public Employees Employees { get; set; }
        [Required]
        public int EmployeesId { get; set; }


    }
}
