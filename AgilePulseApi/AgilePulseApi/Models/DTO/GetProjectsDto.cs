namespace AgilePulseApi.Models.DTO
{
    public class GetProjectsDto
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string LeadId { get; set; }
    }
}
