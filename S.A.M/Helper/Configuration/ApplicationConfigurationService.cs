using Microsoft.Extensions.Options;
using S.A.M.Helper.Email;
using S.A.M.Models.Configurations;

namespace S.A.M.Helper.Configuration;

public class ApplicationConfigurationService : IApplicationConfigurationService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly IOptions<ApplicationConfigurationModel> _appConfigOptions;
    private readonly IOptions<EmailConfiguration> _emailOptions;
    private readonly IOptions<AspIdentityDefault> _identityDefaultOptions;

    private ApplicationConfigurationModel _appConfigModel;
    private EmailConfiguration _emailConfiguration;
    private AspIdentityDefault _aspIdentityDefault;

    private readonly IWebHostEnvironment _environment;

    public ApplicationConfigurationService(IServiceScopeFactory serviceScopeFactory,
        IWebHostEnvironment environment)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _environment = environment;

        var scope = _serviceScopeFactory.CreateScope();

        _appConfigOptions = scope.ServiceProvider.GetRequiredService<IOptions<ApplicationConfigurationModel>>();
        _appConfigModel = new ApplicationConfigurationModel();
        _appConfigModel.PublicTitle = _appConfigOptions.Value.PublicTitle;
        _appConfigModel.DashboardTitle = _appConfigOptions.Value.DashboardTitle;

        //_imageUploadingConfigurationOptions = scope.ServiceProvider.GetRequiredService<IOptions<ImageUploadingConfiguration>>();
        //_imageUploadingConfiguration = new ImageUploadingConfiguration();
        //_imageUploadingConfiguration.MaximumFileLength = _imageUploadingConfigurationOptions.Value.MaximumFileLength;
        //_imageUploadingConfiguration.RootDirectory = WebRoot + @"\" + _imageUploadingConfigurationOptions.Value.RootDirectory;
        //_imageUploadingConfiguration.ReceiptPrefixImageName = _imageUploadingConfigurationOptions.Value.ReceiptPrefixImageName;
        //_imageUploadingConfiguration.ChildPrefixImageName = _imageUploadingConfigurationOptions.Value.ChildPrefixImageName;
        //_imageUploadingConfiguration.FatherPrefixImageName = _imageUploadingConfigurationOptions.Value.FatherPrefixImageName;
        //_imageUploadingConfiguration.MotherPrefixImageName = _imageUploadingConfigurationOptions.Value.MotherPrefixImageName;

        //_objectStorageConfigurationOptions = scope.ServiceProvider.GetRequiredService<IOptions<ObjectStorageConfiguration>>();
        //_objectStorageConfiguration = new ObjectStorageConfiguration();
        //_objectStorageConfiguration.DefaultBucketName = _objectStorageConfigurationOptions.Value.DefaultBucketName;
        //_objectStorageConfiguration.TestBucketName = _objectStorageConfigurationOptions.Value.TestBucketName;


        _emailOptions = scope.ServiceProvider.GetRequiredService<IOptions<EmailConfiguration>>();
        _emailConfiguration = new EmailConfiguration();
        _emailConfiguration.From = _emailOptions.Value.From;
        _emailConfiguration.PortPublished = _emailOptions.Value.PortPublished;
        _emailConfiguration.SmtpServer = _emailOptions.Value.SmtpServer;
        _emailConfiguration.UserName = _emailOptions.Value.UserName;
        _emailConfiguration.Password = _emailOptions.Value.Password;
        _emailConfiguration.PortLocal = _emailOptions.Value.PortLocal;

        _identityDefaultOptions = scope.ServiceProvider.GetRequiredService<IOptions<AspIdentityDefault>>();
        _aspIdentityDefault = new AspIdentityDefault();
        _aspIdentityDefault.AdminRole = _identityDefaultOptions.Value.AdminRole;
        _aspIdentityDefault.SystemWonerRole = _identityDefaultOptions.Value.SystemWonerRole;
        _aspIdentityDefault.ContentManagerRole = _identityDefaultOptions.Value.ContentManagerRole;
        _aspIdentityDefault.ContentCreatorRole = _identityDefaultOptions.Value.ContentCreatorRole;
        _aspIdentityDefault.ContentDrafterRole = _identityDefaultOptions.Value.ContentDrafterRole;
        _aspIdentityDefault.VisitorRole = _identityDefaultOptions.Value.VisitorRole;
        _aspIdentityDefault.AdminUser = _identityDefaultOptions.Value.AdminUser;
        _aspIdentityDefault.SystemWonerUser = _identityDefaultOptions.Value.SystemWonerUser;

    }

    public ApplicationConfigurationModel ApplicationConfigurationModel { get { return _appConfigModel; } }
    public EmailConfiguration EmailConfiguration { get { return _emailConfiguration; } }
    public AspIdentityDefault AspIdentity { get { return _aspIdentityDefault; } }

    public string WebRoot { get { return _environment.WebRootPath; } }
    public string ImagesFolder { get { return Path.Combine(_environment.WebRootPath, "img"); } }
    public string LogoFolder { get { return Path.Combine(ImagesFolder, "logo"); } }
    public string DownloadFolder { get { return Path.Combine(WebRoot, "Download"); } }
    public string PreviewFolder { get { return Path.Combine(WebRoot, "Preview"); } }
}
