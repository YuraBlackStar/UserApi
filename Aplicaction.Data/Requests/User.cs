using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Aplicaction.Data.Requests
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(14,MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Address { get; set; }

    }
}
