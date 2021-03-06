﻿using BookStoreProject.Models.ORM.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreProject.Models.VM
{
    public class UserVM
    {
        public int UserID { get; set; }

        //[Required(ErrorMessage = "Name field is required.")]
        public string Name { get; set; }
        public string SurName { get; set; }

        //[Required(ErrorMessage = "User Name field is required.")]
        [StringLength(8, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Email field is required.")]
        public string UserEmail { get; set; }


        [Required(ErrorMessage = "Password field is required.")]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password field is required.")]
        [Compare("UserPassword", ErrorMessage = "The password and confirmation password do not match.")]
        //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 or 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (eg. !@#$%^&*)")]
        public string ConfirmPassword { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime AddDate { get; set; }= DateTime.Now;
       
        public bool IsDeleted { get; set; }
        public List<Comment> Comments { get; set; }

        public DateTime Lastlogindate { get; set; }
    }
}
