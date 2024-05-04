using System.ComponentModel.DataAnnotations;

namespace AgilePulseApi.Models.Domain
{
    public class ScrumUser
    {
        [Key]
        public Guid ScrumUserId { get; set; } = Guid.NewGuid();
        [Required]
        public string ScrumUsername { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Issue> issues { get; set; }
        public List<Project> projects { get; set; }
        //MM
        public virtual ICollection<ScrumUserProject> ScrumUserProjects { get; set; }

    }
}
