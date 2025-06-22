using S.A.M.Helper.Email;
using S.A.M.Models.Configurations;

namespace S.A.M.Helper.Configuration;

public interface IApplicationConfigurationService
{
    ApplicationConfigurationModel ApplicationConfigurationModel { get; }
    EmailConfiguration EmailConfiguration { get; }
    AspIdentityDefault AspIdentity { get; }
    string DownloadFolder { get; }
    string PreviewFolder { get; }
    string WebRoot { get; }
    string ImagesFolder { get; }
    string LogoFolder { get; }
}
