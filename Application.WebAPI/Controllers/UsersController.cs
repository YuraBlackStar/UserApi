using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicaction.Data.Requests;
using Aplicaction.Data.Responses;
using Aplicaction.Data.Responses.Adapters;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        //// GET: api/User
        //[HttpGet("All")]
        //public IEnumerable<User> Users()
        //{
        //    return UserAdapter.ToUser(_userService.GetAll()); ;
        //}

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<UserDTO> User(int id)
        {
            var result = UserAdapter.ToUserDTO(_userService.GetById(id));
            if (result == null)
            {
               return NotFound("No se ha encontrado el usuario");
            }
            return result;
        }


        // POST: api/User
        
        [HttpPost("Create",Name = "Create")]
        public ActionResult Create([FromBody] User user)
        {
            var bbddUser = UserAdapter.ToNewUserDomain(user);
            _userService.AddElement(bbddUser);
            return Ok();
        }

        // POST: api/User
        [HttpPost("Update", Name = "Update")]
        public ActionResult Update([FromBody] User user)
        {

            var userBD = _userService.GetById(user.Id);
            if (userBD != null)
            {
                UserAdapter.ToUserDomain(user, userBD);
                _userService.UpdateElement(userBD);
            }
            else
            {
                NotFound();
            }
            return Ok();
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}/Delete" ,Name = "Delete")]
        public ActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteElement(id);
                return Ok();
            }
            catch (Exception e)
            {
                return NotFound();
            }

        }
    }
}
