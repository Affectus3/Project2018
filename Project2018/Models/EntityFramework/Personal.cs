//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project2018.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Personal
    {
        public int Id { get; set; }
        [Display(Name ="Department Name")]
        [Required(ErrorMessage ="Department Name is requried")]
        public Nullable<int> DepartmentId { get; set; }        
        [Required(ErrorMessage = "Name is requried")]
        public string Name { get; set; }        
        [Required(ErrorMessage = "Surname is requried")]
        public string Surname { get; set; }
        [Range(1800,8000, ErrorMessage = "Salary has to be between 1800-8000")]
        [Required(ErrorMessage = "Salary is requried")]
        public Nullable<short> Salary { get; set; }
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date is requried")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [Required(ErrorMessage = "Sex Field is requried")]
        public bool Sex { get; set; }
        [Display(Name = "Civil Status")]
        public bool IsMarried { get; set; }
    
        public virtual Department1 Department1 { get; set; }
    }
}
