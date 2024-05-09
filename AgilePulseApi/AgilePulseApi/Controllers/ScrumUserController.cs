using AgilePulseApi.Data;
using AgilePulseApi.Models.Domain;
using AgilePulseApi.Models.DTO;
using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace AgilePulseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScrumUserController : Controller
    {
        private readonly IMapper mapper;
        private readonly ScrumDbContext scrumDbContext;
        private readonly IConfiguration configuration;

        public ScrumUserController(IMapper mapper, ScrumDbContext scrumDbContext, IConfiguration configuration)
        {
            this.mapper = mapper;
            this.scrumDbContext = scrumDbContext;
            this.configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var scrumusers = await scrumDbContext.ScrumUser.ToListAsync();
            return Ok(scrumusers);
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> CreateScrumUser([FromBody]AddScrumUser addScrumUser)
        {
            // convert dto to domain
            var scrumUserDomain = new ScrumUser
            {
                ScrumUsername = addScrumUser.ScrumUsername,
                Email = addScrumUser.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(addScrumUser.Password)
            };
            // check if user already exists
            var existingUser = await scrumDbContext.ScrumUser.FirstOrDefaultAsync(x=>x.Email == scrumUserDomain.Email);
            if(existingUser != null) { return BadRequest("User Already Exists"); }
            try
            {
                var createScrumUser = await scrumDbContext.ScrumUser.AddAsync(scrumUserDomain);
                await scrumDbContext.SaveChangesAsync();
                return Ok(mapper.Map<ScrumUserDto>(createScrumUser.Entity));
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [EnableCors]
        [Route("login")]
        public async Task<IActionResult> LoginScrumUser([FromBody] LoginScrumUserDTO loginScrumUserDTO)
        {

            // check if user does not exists
            try
            {
                var checkUser = await scrumDbContext.ScrumUser.FirstOrDefaultAsync(x => x.Email == loginScrumUserDTO.Email);
                if (checkUser == null) { return BadRequest("Invalid Credentials"); }
                // check password hashing
                var verifyPassword = BCrypt.Net.BCrypt.Verify(loginScrumUserDTO.Password, checkUser.Password);
                if (verifyPassword)
                {
                    // Generate Token
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var claims = new[]
                    {
                        new Claim("Name", checkUser.ScrumUsername),
                        new Claim("Email", checkUser.Email)
                    };

                    var token = new JwtSecurityToken(
                        configuration["Jwt:Issuer"],
                        configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(60),
                        signingCredentials: credentials
                        );
                    var loginToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new { token= loginToken });
                }
                return BadRequest("Invalid Credentials");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
