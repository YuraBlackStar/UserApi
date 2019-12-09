using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.Domain.Entities
{
    public class UserDomain : IUserDomain
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(14)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        [StringLength(40)]
        public string Address { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
