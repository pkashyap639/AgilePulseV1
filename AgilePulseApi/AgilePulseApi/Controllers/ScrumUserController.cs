using AgilePulseApi.Data;
using AutoMapper;
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
            var scrumusers = await scrumDbContext.ScumUser.ToListAsync();
            return Ok(scrumusers);
        }
    }
}
