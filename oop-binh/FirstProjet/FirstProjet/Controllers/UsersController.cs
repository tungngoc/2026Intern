using AutoMapper;
using BCrypt.Net;
using FirstProjet.Data;
using FirstProjet.DTOs.Request;
using FirstProjet.DTOs.Response;
using FirstProjet.Models;
using FirstProjet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FirstProjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService, IMapper mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var data = await userService.getUserById(id);
            var res = mapper.Map<UserResponse>(data);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateRequest request)
        {
            var user = await userService.createUser(request);
            return CreatedAtAction(
                nameof(GetUserById),
                new { id = user.Id },
                mapper.Map<UserResponse>(user)
                );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await userService.getAllUsers();
            var res = users.Select(mapper.Map<UserResponse>);
            return Ok(res);
        }
    }
}
