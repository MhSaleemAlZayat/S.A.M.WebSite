using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace S.A.M.Data.Entities.AspIdentity;

public class Role : IdentityRole
{

    public bool? System { get; set; } = false;
    public bool? Preview { get; set; } = true;
    public bool? Active { get; set; } = true;
    public bool? IsDeleted { get; set; } = false;
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    [MaxLength(64)]
    public string CreatedBy { get; set; }
    [MaxLength(64)]
    public string? UpdatedBy { get; set; }
}
