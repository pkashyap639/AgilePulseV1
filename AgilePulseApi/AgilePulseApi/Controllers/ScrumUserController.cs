using AgilePulseApi.Data;
using AgilePulseApi.Models.Domain;
using AgilePulseApi.Models.DTO;
using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgilePulseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScrumUserController : Controller
    {
        private readonly IMapper mapper;
        private readonly ScrumDbContext scrumDbContext;
        

        public ScrumUserController(IMapper mapper, ScrumDbContext scrumDbContext)
        {
            this.mapper = mapper;
            this.scrumDbContext = scrumDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var scrumusers = await scrumDbContext.ScrumUser.ToListAsync();
            return Ok(scrumusers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateScrumUser(AddScrumUser addScrumUser)
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
    }
}
