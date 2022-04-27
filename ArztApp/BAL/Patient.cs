using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArztApp.BAL
{
    public partial class Patient
    {
        public Patient()
        {
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }

        [Required]  
        [NotMapped]
        public bool selectedGender { get; set; }
        [Required(ErrorMessage = "Firstname is required and must not be empty.")]
        public string Firstname { get; set; } = null!;
        [Required(ErrorMessage = "Surname is required and must not be empty.")]
        public string Surname { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; } = null!;
        public int Zip { get; set; }
        public string City { get; set; } = null!;

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
