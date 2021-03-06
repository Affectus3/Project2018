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

    public partial class User1
    {        
        public int Id { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [Display(Name="Username")]
        public string Name { get; set; }
        [Required(ErrorMessage = "User password is required")]
        public string Password { get; set; }
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Just Alphabet")]
        [Required(ErrorMessage = "User role is required")]
        public string Role { get; set; }
    }
}
