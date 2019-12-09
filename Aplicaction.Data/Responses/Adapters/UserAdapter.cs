using Aplicaction.Data.Requests;
using Core.Domain.Entities;
using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicaction.Data.Responses.Adapters
{
    public static class UserAdapter
    {

        public static List<User> ToUser(IEnumerable<IUserDomain> users)
        {
            var result = new List<User>();
            foreach (var user in users)
            {
                result.Add(ToUser(user));
            }
            return result;
        }

        public static User ToUser(IUserDomain user)
        {
            if (user == null)
                return null;
            return new User
            {
                Id= user.Id,
                Address = user.Address?.Trim() ?? string.Empty,
                LastName = user.LastName?.Trim() ?? string.Empty,
                Name = user.Name?.Trim() ?? string.Empty

            };
        }

        public static UserDTO ToUserDTO(IUserDomain user)
        {
            if (user == null)
                return null;
            return new UserDTO
            {
                Address = user.Address?.Trim() ?? string.Empty,
                LastName = user.LastName?.Trim() ?? string.Empty,
                Name = user.Name?.Trim() ?? string.Empty,
                CreateDate = user.CreateDate,
                UpdateDate = user.UpdateDate,
                Id = user.Id
            };
        }


        public static void  ToUserDomain(User user, IUserDomain userDomain)
        {
            userDomain.Id = user.Id;
            userDomain.Address = user.Address?.Trim();
            userDomain.LastName = user.LastName?.Trim();
            userDomain.Name = user.Name?.Trim();

        }
        public static IUserDomain ToNewUserDomain(User user)
        {
            UserDomain userDomain = new UserDomain();
            userDomain.Address = user.Address?.Trim();
            userDomain.LastName = user.LastName?.Trim();
            userDomain.Name = user.Name?.Trim();
            userDomain.Id = user.Id;
            return userDomain;
        }


    }
}
