using AgilePulseApi.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace AgilePulseApi.Models.DTO
{
    public class GetIssueDTO
    {
        public Guid IssueId { get; set; }
        public string IssueTitle { get; set; }
        public string IssueDescription { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // Foreign Keys
        public ScrumUserDto scrumUser { get; set; }
        public GetProjectsDto project { get; set; }
        public GetCycleDTO? cycle { get; set; }
    }
}
