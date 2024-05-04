using System.ComponentModel.DataAnnotations;

namespace AgilePulseApi.Models.Domain
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; } = Guid.NewGuid();
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        // Foreign Key
        public Guid LeadId { get; set; }
        public ScrumUser scrumUser { get; set; }
        public List<Project> projects { get; set; }
        public List<Issue> issues { get; set; }

        //MM
        public virtual ICollection<ScrumUserProject> ScrumUserProjects { get; set; }

    }
}
