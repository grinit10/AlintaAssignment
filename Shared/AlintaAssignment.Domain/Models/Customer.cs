using System;
using System.ComponentModel.DataAnnotations;

namespace AlintaAssignment.Domain.Models
{
    public class Customer : BaseModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
