using System;
using System.ComponentModel.DataAnnotations;

namespace IS4439_Assignment.Models
{
    public class LogInViewModel
    {
        public LogInViewModel()
        {
        }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
