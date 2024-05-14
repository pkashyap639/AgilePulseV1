using System.ComponentModel.DataAnnotations;

namespace AgilePulseApi.Models.Domain
{
    public class Issue
    {
        [Key]
        public Guid IssueId { get; set; } = Guid.NewGuid();
        [Required]
        public string IssueTitle { get; set; }
        public string IssueDescription { get; set; }
        [Required]
        public string Status { get; set; } = "Todo";
        [Required]
        public string Priority { get; set; } = "Low";
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        // Foreign Keys
        public Guid scrumUserId { get; set; }
        public ScrumUser scrumUser { get; set; }
        public Guid projectId { get; set; }
        public Project project { get; set; }
        public Guid? cycleId { get; set; }
        public Cycle cycle { get; set; }
    }
}
