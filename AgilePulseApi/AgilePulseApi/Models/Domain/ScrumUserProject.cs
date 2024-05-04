namespace AgilePulseApi.Models.Domain
{
    public class ScrumUserProject
    {
        public Guid ScrumUserId { get; set; }
        public Guid ProjectId { get; set; }
        public ScrumUser ScrumUser { get; set; }
        public Project Project { get; set; }
    }
}