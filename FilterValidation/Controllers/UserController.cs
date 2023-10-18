using FilterValidation.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FilterValidation.FluentValidation;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using FluentValidation;
using FilterValidation.Dto_s;
using FilterValidation.Interfaca;
using FilterValidation.Filters;
using System.Xml.Linq;
using FilterValidation.Entities;

namespace FilterValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepaasitory _appDbContext;
        private readonly IValidator<UserDto> _validator;

        public UserController(IUserRepaasitory appDbContext, IValidator<UserDto> validator)
        {
            _appDbContext = appDbContext;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser() => Ok(await _appDbContext.GetAllUsers());
        [TypeFilter(typeof(CheckFilterUser))]
        [HttpPost("id")]
        public async Task<IActionResult> GetUserById(int id) => Ok(await _appDbContext.GetUserById(id));
        [TypeFilter(typeof(CheckFilterUser))]
        [HttpGet("name")]
        public async Task<IActionResult> GetUserByNamr(string name)
        {

            return Ok(await _appDbContext.GetUserByName(name));
        }
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var volidaton = await _validator.ValidateAsync(userDto);
            if (!volidaton.IsValid)
            {
                return BadRequest(volidaton.Errors);
            }
            return Ok(await _appDbContext.CreateUser(userDto));
        }
        public async Task<IActionResult> UpdateUser([FromForm] int id, User userDto) => Ok(_appDbContext.UpdateUser(id, userDto));
        [TypeFilter(typeof(CheckFilterUser))]
        [HttpDelete]
        public async Task<IActionResult> DeleteUSer([FromForm] int id)
        {
            await _appDbContext.DeleteUser(id);
            return Ok("Delete USer");
        }


    }
}
