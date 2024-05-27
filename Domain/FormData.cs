using System.ComponentModel.DataAnnotations;

namespace RegistrationForm.Domain
{
    public class FormData
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string? Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
