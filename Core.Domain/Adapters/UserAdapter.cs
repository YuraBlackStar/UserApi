using Core.Domain.Entities;
using Core.Domain.Interfaces;
using Infrastructure.Data.Core.Entities;
using Infrastructure.Data.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Core.Domain.Adapters
{
    public static class UserAdapter
    {
        public static IUser MapUser(IUserDomain user)
        {
            return new User
            {
                Id = user.Id,
                Address = user.Address,
                CreateDate = user.CreateDate,
                LastName = user.LastName,
                Name = user.Name,
                UpdateDate = user.UpdateDate

            };
        }

        public static IUserDomain ToDomainUser(IUser user)
        {
            if (user == null) return null;
            return new UserDomain
            {
                Id = user.Id,
                Address = user.Address,
                CreateDate = user.CreateDate,
                LastName = user.LastName,
                Name = user.Name,
                UpdateDate = user.UpdateDate 

            };
        }

        public static IEnumerable<IUserDomain>  ToDomainUser(IEnumerable<IUser> user)
        {
            return user.Select(x => ToDomainUser(x));
        }

    }
}
