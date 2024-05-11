using AgilePulseApi.Data;
using AgilePulseApi.Models.Domain;
using AgilePulseApi.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AgilePulseApi.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IMapper mapper;
        private readonly ScrumDbContext scrumDbContext;

        public ProjectController(IMapper mapper, ScrumDbContext scrumDbContext)
        {
            this.mapper = mapper;
            this.scrumDbContext = scrumDbContext;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> getAllProjects(Guid id)
        {
            // get projects if from scrumproject table
            var projectIds = await scrumDbContext.ScrumUserProject.Where(x => x.ScrumUserId == id).Include(x => x.Project).ToListAsync();
            return Ok(mapper.Map<List<OnlyProjectDTO>>(projectIds));
        }
        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> AddProject(AddProjectDto addProjectDto)
        {
            // convert dto to domain
            var addProjectDomain = mapper.Map<Project>(addProjectDto);
            // check if user exists using guid
            var userExists = await scrumDbContext.ScrumUser.FirstOrDefaultAsync(x => x.ScrumUserId == addProjectDomain.LeadId);
            if (userExists == null) {
                return BadRequest();
            }
            var newProjectDomain = new Project
            {
                Title = addProjectDomain.Title,
                Description = addProjectDomain.Description,
                LeadId = addProjectDomain.LeadId
            };
            var addProject = await scrumDbContext.Projects.AddAsync(newProjectDomain);
            await scrumDbContext.SaveChangesAsync();
            var projectScrumId = new ScrumUserProject {
                ScrumUserId = userExists.ScrumUserId,
                ProjectId = addProject.Entity.ProjectId
            };
            var addProjectScrum = await scrumDbContext.ScrumUserProject.AddAsync(projectScrumId);
            await scrumDbContext.SaveChangesAsync();
            return Ok(new { msg = "Project Added Successfully" });
        }

        [HttpDelete]
        [Route("{LeadId}/{ProjectId}")]
        public async Task<IActionResult> DeleteProject(Guid LeadId, Guid ProjectId)
        {
            // check lead and project
            var project = await scrumDbContext.Projects.Where(x=>x.LeadId == LeadId && x.ProjectId == ProjectId).FirstOrDefaultAsync();
            scrumDbContext.Remove(project);
            await scrumDbContext.SaveChangesAsync();
            return Ok(new { msg = "Project Deleted"});
        }

    }
}
