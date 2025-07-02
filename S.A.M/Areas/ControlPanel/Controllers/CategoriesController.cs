using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using S.A.M.Areas.ControlPanel.Models.Category;
using S.A.M.Data.Repositories.Categories;
using S.A.M.Data.Repositories.Languages;
using S.A.M.Models.Category;

namespace S.A.M.Areas.ControlPanel.Controllers
{
    public class CategoriesController : ControlPanelBaseController
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILogger<CategoriesController> _logger;

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryRepository categoryRepository, ILogger<CategoriesController> logger, IConfiguration configuration, IMapper mapper, ILanguageRepository languageRepository)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        public async Task<IActionResult> Index()
        {
            var defaultLanguage = await _languageRepository.GetDefaultLanguageAsync();
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            if (categories == null || !categories.Any())
            {
                _logger.LogInformation("No categories found.");
                categories = new List<S.A.M.Data.Entities.Category>();
            }

            CategoryIndexViewModel categoryIndexViewModel = new CategoryIndexViewModel
            {
                DefaultLanguageId = defaultLanguage.Id,
                Categories = _mapper.Map<List<CategoryModel>>(categories)
            };

            return View(categoryIndexViewModel);
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }
    }
}
