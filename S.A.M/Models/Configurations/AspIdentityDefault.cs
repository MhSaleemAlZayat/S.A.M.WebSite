namespace S.A.M.Models.Configurations;

public class AspIdentityDefault
{
    public DefaultRole AdminRole { get; set; } = new DefaultRole();
    public DefaultRole SystemWonerRole { get; set; } = new DefaultRole();
    public DefaultRole ContentManagerRole { get; set; } = new DefaultRole();
    public DefaultRole ContentCreatorRole { get; set; } = new DefaultRole();
    public DefaultRole ContentDrafterRole { get; set; } = new DefaultRole();
    public DefaultRole VisitorRole { get; set; } = new DefaultRole();

    public DefaultUser AdminUser { get; set; } = new DefaultUser();
    public DefaultUser SystemWonerUser { get; set; } = new DefaultUser();

    public List<DefaultRole> Roles =>
        new List<DefaultRole> { AdminRole, SystemWonerRole, ContentManagerRole, ContentCreatorRole, ContentDrafterRole, VisitorRole };
}