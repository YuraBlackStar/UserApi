using Infrastructure.Data.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infrastructure.Data.Core.Entities
{
    public class User : IUser
    {

        [Key]
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

        [Column(TypeName = "CreateDate")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "UpdateDate")]
        public DateTime? UpdateDate { get; set; }


    }
}
