using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using S.A.M.Data.Repositories.Languages;
using S.A.M.Models.Language;

namespace S.A.M.Areas.ControlPanel.Controllers;

public class LanguageController : ControlPanelBaseController
{
    private readonly ILogger<LanguageController> _logger;
    private readonly ILanguageRepository _languageRepository;
    private readonly IMapper _mapper;
    public LanguageController(ILogger<LanguageController> logger, ILanguageRepository languageRepository, IMapper mapper)
    {
        _logger = logger;
        _languageRepository = languageRepository;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        try
        {
            var languageEntities = await _languageRepository.GetAllLanguagesAsync();

            return View(_mapper.Map<List<LanguageModel>>(languageEntities));
        }
        catch (Exception exp)
        {

            throw;
        }
    }

    [HttpGet]
    [Route("sam/api/[controller]/[action]")]
    public async Task<IActionResult> ChangeDefaultLanguage(byte id)
    {
        try
        {
            var changed = await _languageRepository.ChangeDefaultLanguageAsync(id);

            if (!changed)
            {
                return BadRequest(new { success = false, message = "Failed to change the default language." });
            }
            else
            {
                return Ok(new { success = true, message = "Default language changed successfully." });
            }

        }
        catch (Exception exp)
        {
            return BadRequest(new { success = false, message = "An error occurred while changing the default language.", error = exp.Message });
        }
    }

    [HttpGet]
    [Route("sam/api/[controller]/[action]")]
    public async Task<IActionResult> ChangeLanguageActivationStatus(byte id)
    {
        try
        {
            var changed = await _languageRepository.ChangeLanguageActivationStatusAsync(id);
            if (changed == null)
            {
                return BadRequest(new { success = false, message = "Failed to change the language activation status." });
            }
            else
            {
                return Ok(new { success = true, message = "Language activation status changed successfully.", active = changed.Active });
            }

        }
        catch (InvalidOperationException invalidOperationEx)
        {
            _logger.LogError(invalidOperationEx, "Error changing language activation status");
            return BadRequest(new { success = false, message = "يجب أن تكون هناك لغة واحدة نشطة على الأقل.", error = invalidOperationEx.Message });
        }
        catch (Exception exp)
        {
            _logger.LogError(exp, "Error changing language activation status");
            return BadRequest(new { success = false, message = "An error occurred while changing the default language.", error = exp.Message });
        }
    }


}
