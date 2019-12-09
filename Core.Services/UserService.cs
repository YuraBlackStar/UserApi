using Core.Domain.Interfaces;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Data.Interfaces.Entities;
using System;
using System.Collections.Generic;
using Core.Domain.Adapters;

namespace Core.Services
{

    public class UserService : IUserService
    {
        private readonly IAppParameters parameters;
        private readonly IUserRepository userRepository;

        public UserService(IAppParameters parameters, IUserRepository userRepository)
        {
            this.parameters = parameters;
            this.userRepository = userRepository;
        }

        public void AddElement(IUserDomain element)
        {
            var user = UserAdapter.MapUser(element);
            userRepository.AddElement(user);
        }

        public void DeleteElement(int id)
        {
            var user = userRepository.GetById(id);
            if (user==null)
            {
                throw new Exception("No se ha encontrado el usuario");
            }
            userRepository.DeleteElement(user);
          
        }

        public IEnumerable<IUserDomain> GetAll()
        {
            return UserAdapter.ToDomainUser(userRepository.GetAll());
            
        }

        public IUserDomain GetById(int id)
        {
            return UserAdapter.ToDomainUser(userRepository.GetById(id));
            
        }

        public void UpdateElement(IUserDomain element)
        {

            var user = UserAdapter.MapUser(element);
            userRepository.UpdateElement(user);
            
            //throw new NotImplementedException();
        }



        //Metods

    }
}
