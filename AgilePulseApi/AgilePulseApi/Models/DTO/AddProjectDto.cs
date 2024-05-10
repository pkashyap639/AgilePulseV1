using AgilePulseApi.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace AgilePulseApi.Models.DTO
{
    public class AddProjectDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid LeadId { get; set; }
    }
}
