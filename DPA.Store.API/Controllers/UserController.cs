using DPA.Store.DOMAIN.Core.Entities;
using DPA.Store.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            _userRepository.Insert(user);
            return Ok();
        }

        [HttpGet("SignIn")]
        public async Task<IActionResult> SignIn(string email, string clave) 
        {
            var respuesta = await _userRepository.SignIn(email,clave);
            if(respuesta)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var respuesta = await _userRepository.Delete(id);
            if (respuesta)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }



    }
}
