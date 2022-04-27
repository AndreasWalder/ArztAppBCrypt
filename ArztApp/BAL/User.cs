using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArztApp.BAL
{
    public partial class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = null!;
        [Required]
        public string Pass { get; set; } = null!;
        public DateTime RegDate { get; set; }
    }
}
