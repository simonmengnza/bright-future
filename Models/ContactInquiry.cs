using System;
using System.ComponentModel.DataAnnotations;

namespace Bright_Future.Models
{
    public class ContactInquiry
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SubmissionDate { get; set; }

        public bool IsProcessed { get; set; }
    }
}