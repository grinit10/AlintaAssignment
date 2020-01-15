using System;
using System.ComponentModel.DataAnnotations;

namespace AlintaAssignment.Domain.ViewModels
{
    public class PostCustomerVm
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
