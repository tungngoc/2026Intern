using FirstProjet.DTOs.Request;
using FirstProjet.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstProjet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController (
    IAuthService _authService
    ): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> login(AuthRequest request)
    {
        var data = await _authService.Login(request.Username, request.Password);
        return Ok(data);
    }
}