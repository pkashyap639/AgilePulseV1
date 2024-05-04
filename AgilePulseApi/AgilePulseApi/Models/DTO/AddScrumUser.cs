using System.ComponentModel.DataAnnotations;

namespace AgilePulseApi.Models.DTO
{
    public class AddScrumUser
    {
        public string ScrumUsername { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
