using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Interfaces.Entities
{
    public interface IUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
