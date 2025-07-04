using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using S.A.M.Areas.ControlPanel.Models.Category;
using S.A.M.Data.Repositories.Categories;
using S.A.M.Data.Repositories.Languages;
using S.A.M.Helper.Slug;
using S.A.M.Models.Category;
using S.A.M.Models.Language;
using static S.A.M.Helper.Slug.SlugGeneratorService;

namespace S.A.M.Areas.ControlPanel.Controllers
{
    public class CategoriesController : ControlPanelBaseController
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILogger<CategoriesController> _logger;

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ISlugGenerator _slugGenerator;
        public CategoriesController(ICategoryRepository categoryRepository, ILogger<CategoriesController> logger, IConfiguration configuration, IMapper mapper, ILanguageRepository languageRepository, ISlugGenerator slugGenerator)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _configuration = configuration;
            _mapper = mapper;
            _languageRepository = languageRepository;
            _slugGenerator = slugGenerator;
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

        [HttpGet]
        [Route("sam/api/[controller]/[action]")]
        public async Task<IActionResult> GetCategorySlugByLanguageId(string input, byte languageId)
        {
            try
            {
                var slug = await _slugGenerator.GenerateSlugAsync(input, SlugType.Category, languageId, true);

                return Ok(new { success = true, data = slug });
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Error fetching categories by language ID.");
                return BadRequest(new { success = false, message = "An error occurred while fetching categories.", error = exp.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                var languages = await _languageRepository.GetAllLanguagesAsync();
                var categories = await _categoryRepository.GetAllCategoriesAsync();
                AddCategoryViewModel viewModel = new()
                {
                    Languages = _mapper.Map<List<LanguageModel>>(languages),
                    Categories = _mapper.Map<List<CategoryModel>>(categories),
                };



                return View(viewModel);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Error fetching categories by language ID.");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryModel category)
        {
            try
            {

                var categoryEntity = _mapper.Map<S.A.M.Data.Entities.Category>(category);
                categoryEntity.CreatedAt = DateTime.UtcNow;
                categoryEntity.CreatedBy = UserId;
                foreach (var translation in categoryEntity.Translations)
                {
                    translation.CreatedAt = DateTime.UtcNow;
                    translation.CreatedBy = UserId;
                    translation.Slug = await _slugGenerator.GenerateSlugAsync(translation.Name, SlugType.Category, translation.LanguageId, true);
                }
                await _categoryRepository.AddCategoryAsync(categoryEntity);
                TempData["AddCategoryState"] = "Success";
                return Redirect("/ControlPanel/Categories/Add");
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, "Error fetching categories by language ID.");
                throw;
            }
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
