using Moq;
using S.A.M.Helper.Slug;
using S.A.M.Helper.Slug.UniquenessCheckerPolicies;

namespace S.A.M.Tests.Slug;

public class SlugGeneratorServiceTests
{
    [Fact]
    public async Task GenerateSlugAsync_BasicSlugification_WorksCorrectly()
    {
        var service = new SlugGeneratorService();
        var result = await service.GenerateSlugAsync("Hello World!", SlugGeneratorService.SlugType.Article, 1);
        Assert.Equal("hello-world", result);
    }

    [Fact]
    public async Task GenerateSlugAsync_ThrowsOnEmptyInput()
    {
        var service = new SlugGeneratorService();
        await Assert.ThrowsAsync<ArgumentException>(() => service.GenerateSlugAsync(" ", SlugGeneratorService.SlugType.Article, 1));
    }

    [Fact]
    public async Task GenerateSlugAsync_EnsuresUniqueSlug_WhenNotUnique()
    {
        var policy = new Mock<IUniquenessCheckerPolicy>();
        policy.Setup(x => x.IsApplicableTo(SlugGeneratorService.SlugType.Category)).Returns(true);
        policy.SetupSequence(x => x.IsUniqueAsync(It.IsAny<string>(), 2))
            .ReturnsAsync(false) // first try: not unique
            .ReturnsAsync(true); // second try: unique

        var service = new SlugGeneratorService(new[] { policy.Object });
        var result = await service.GenerateSlugAsync("Test Slug", SlugGeneratorService.SlugType.Category, 2, ensureUnique: true);
        Assert.Equal("test-slug-1", result);
    }

    [Fact]
    public async Task GenerateSlugAsync_EnsuresUniqueSlug_WhenAlreadyUnique()
    {
        var policy = new Mock<IUniquenessCheckerPolicy>();
        policy.Setup(x => x.IsApplicableTo(SlugGeneratorService.SlugType.Tag)).Returns(true);
        policy.Setup(x => x.IsUniqueAsync(It.IsAny<string>(), 3)).ReturnsAsync(true);

        var service = new SlugGeneratorService(new[] { policy.Object });
        var result = await service.GenerateSlugAsync("Unique Slug", SlugGeneratorService.SlugType.Tag, 3, ensureUnique: true);
        Assert.Equal("unique-slug", result);
    }

    [Fact]
    public async Task GenerateSlugAsync_AllowsArabicCharacters()
    {
        var service = new SlugGeneratorService();
        var result = await service.GenerateSlugAsync("„—Õ»« »«·⁄«·„ !! Ê«·⁄«·„ „—Õ»", SlugGeneratorService.SlugType.Page, 1);
        Assert.Equal("„—Õ»«-»«·⁄«·„-Ê«·⁄«·„-„—Õ»", result);
    }
}
