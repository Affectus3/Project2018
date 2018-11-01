using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCEmail.Models
{
    public class EmailFormModel
    {
        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "Name is required")]
        public string FromName { get; set; }        
        [Display(Name = "Your Email")]
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string FromEmail { get; set; }
        [Required(ErrorMessage = "Message field has to be filled")]
        public string Message { get; set; }
        public HttpPostedFileBase Upload { get; set; }
    }
}