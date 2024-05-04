using System.ComponentModel.DataAnnotations;

namespace AgilePulseApi.Models.Domain
{
    public class Cycle
    {
        [Key]
        public Guid CycleId { get; set; } = Guid.NewGuid();
        [Required]
        public string CycleName { get; set; }
        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public List<Issue> issues { get; set; }
    }
}
