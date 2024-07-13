using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PureSOLWorkCase.Data.Jwt;
using PureSOLWorkCase.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PureSOLWorkCase.WebAPI.Controller;

[Route("api/v1.0/[controller]")]
[ApiController]
public class JwtController : ControllerBase
{
    private readonly JwtSettings _jwtSettings;
    private readonly IUserRepository _userRepository;

    public JwtController(IOptions<JwtSettings> jwtSettings, IUserRepository userRepository)
    {
        _jwtSettings = jwtSettings.Value;
        _userRepository = userRepository;
    }

    [HttpPost("JwtTokenForApiUser")]
    public async Task<IActionResult> JwtTokenForApiUser([FromBody] UserDto userDto)
    {
        var userInformation = await CheckUser(userDto);
        if (userInformation is null) return NotFound("User was not found");

        var token = CreateJwtToken(userInformation);


        return Ok(token);
    }

    private string CreateJwtToken(User user)
    {
        if (_jwtSettings.Key is null) throw new Exception("In JwtSettings, Key can not be null");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claimArray = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Name),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claimArray,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: credentials
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private async Task<User?> CheckUser(UserDto userDto)
    {
        return await _userRepository.GetUserByEMailAsync(userDto.Email); ;
    }
}
