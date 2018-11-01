using Project2018.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2018.ViewModels
{
    public class PersonalFormViewModel
    {
        public IEnumerable<Department1> Departments { get; set; }
        public Personal Personal { get; set; }
    }
}