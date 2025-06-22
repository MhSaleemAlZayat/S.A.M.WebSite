using System.ComponentModel.DataAnnotations;

namespace S.A.M.Areas.ControlPanel.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
