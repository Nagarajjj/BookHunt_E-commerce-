using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Customer.ViewModels
{
    public class CustomerDetails
    {
        public short CustomerId { get; set; }
        
        [Required(ErrorMessage = "Name is mandatory")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email Address is mandatory")]
        [EmailAddress(ErrorMessage = "Email Address is not in a proper format")]
        public string CustomerEmailId { get; set; }

        [MinLength(5, ErrorMessage = "Should contain a minimum of 5 characters")]
        [MaxLength(20, ErrorMessage = "Should contain only upto 20 characters including spaces")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Should contain atleast 1 special character and 1 uppercase")]
        [Required(ErrorMessage = "Password is mandatory")]
        public string CustomerPassword { get; set; }

        [Required(ErrorMessage = "Required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Phone number is mandatory")]
        public string CustomerPhNo { get; set; }
    }

    public class LoginView
    {
        [Required(ErrorMessage = "Email Address is mandatory")]
        public string CustomerEmailId { get; set; }



        [Required(ErrorMessage = "Password is mandatory")]
        public string CustomerPassword { get; set; }
    }
}
