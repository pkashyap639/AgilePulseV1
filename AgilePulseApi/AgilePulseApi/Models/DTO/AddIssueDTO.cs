using AgilePulseApi.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace AgilePulseApi.Models.DTO
{
    public class AddIssueDTO
    {
        public string IssueTitle { get; set; }
        public string IssueDescription { get; set; }
        public string Status { get; set; } = "Todo";
        public string Priority { get; set; } = "Low";
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);
        // Foreign Keys
        public Guid scrumUserId { get; set; }
        public Guid projectId { get; set; }


    }
}
