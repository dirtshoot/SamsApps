using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Postal;

namespace Company.Solution.Models
{
    public class EmailMsg : Email
    {
        [Required(ErrorMessage = "Email Address is required"), StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string From { get; set; }

        [Required(ErrorMessage = "Email Address is required"), StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string To { get; set; }

        public string Id { get; set; }

        [Required, StringLength(100)]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Email Message is required")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        public List<UploadFile> EmailFiles { get; set; }
    }

    public class ConfirmEmail : Email
    {
        [Required(ErrorMessage = "Email Address is required"), StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string To { get; set; }
  
        public string Id { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Confirm Url is required")]
        public string ConfirmUrl { get; set; }
    }

    public class ForgotPasswordEmail : Email
    {
        [Required(ErrorMessage = "Email Address is required"), StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string To { get; set; }

        public string Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Reset Url is required")]
        public string ResetUrl { get; set; }
    }

    public class UploadFile
    {
        public string UploadFileName { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string Ext { get; set; }
        
        public string ContentType { get; set; }

        public string Url
        {
            get
            {
                return FilePath + FileName;
            }
        }
    }
}