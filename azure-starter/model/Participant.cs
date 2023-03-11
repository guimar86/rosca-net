using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace azure_starter.model
{
    using System.ComponentModel.DataAnnotations;
    [Table("Participants")]
    public class Participant
    {
        [Key] 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Please enter a valid telephone number.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Please enter an IBAN.")]
        [RegularExpression(@"^[A-Z]{2}\d{2}\s?\d{4}\s?\d{4}\s?\d{4}\s?\d{4}\s?\d{2}$", 
            ErrorMessage = "Please enter a valid IBAN.")]
        public string Iban { get; set; }
    }
}