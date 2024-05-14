using System.ComponentModel.DataAnnotations;

namespace AgilePulseApi.Models.DTO
{
    public class GetCycleDTO
    {
        public Guid CycleId { get; set; } 
        public string CycleName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
