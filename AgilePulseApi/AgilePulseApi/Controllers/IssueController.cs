using AgilePulseApi.Data;
using AgilePulseApi.Models.Domain;
using AgilePulseApi.Models.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgilePulseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IssueController : Controller
    {
        private readonly IMapper mapper;
        private readonly ScrumDbContext scrumDbContext;

        public IssueController(IMapper mapper, ScrumDbContext scrumDbContext)
        {
            this.mapper = mapper;
            this.scrumDbContext = scrumDbContext;
        }

        [HttpGet]
        [EnableCors]
        [Route("{scrumUserId}/{projectId}")]
        public async Task<IActionResult> GetIssue(Guid scrumUserId, Guid projectId)
        {
            // check user and project
            var projectUser = await scrumDbContext.ScrumUserProject.Where(x => x.ScrumUserId == scrumUserId && x.ProjectId == projectId).FirstOrDefaultAsync();
            if(projectUser == null)
            {
                return BadRequest(new { msg = "User or Project does not exists" });
            }

            var issues = await scrumDbContext.Issue.Include(x => x.scrumUser).Include(x => x.project).ToListAsync();
            var issueList = mapper.Map<List<GetIssueDTO>>(issues);
            return Ok(issueList);
        }

        [HttpPost]
        [EnableCors]
        public async Task<IActionResult> AddIssue(AddIssueDTO issueDTO)
        {
            // convert dto to domain
            var issueDomain = mapper.Map<Issue>(issueDTO);
            // check if user is joined with this project
            try
            {
                var checkIfUserJoined = await scrumDbContext.ScrumUserProject.Where(x => x.ScrumUserId == issueDomain.scrumUserId && x.ProjectId == issueDomain.projectId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new {errpr = ex.Message});
            }
            /*if (checkIfUserJoined == null)
            {
                return BadRequest(new { msg = "User Not Associated to this Project"});
            }
*/
            var createIssue = await scrumDbContext.Issue.AddAsync(issueDomain);
            await scrumDbContext.SaveChangesAsync();
            try
            {
                
            }catch(Exception ex) {
                return BadRequest(new { error = ex.Message });
            }
            
            return Ok(new { msg = "Issue Created Successfully" }) ;
        }
    }
}
