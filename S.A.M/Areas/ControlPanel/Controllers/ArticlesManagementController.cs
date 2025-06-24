using Microsoft.AspNetCore.Mvc;

namespace S.A.M.Areas.ControlPanel.Controllers;

public class ArticlesManagementController : ControlPanelBaseController
{

    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> AddArticle()
    {
        return View();
    }

    public async Task<IActionResult> EditArticle(int id)
    {
        // Logic to retrieve the article by id and pass it to the view
        return View();
    }
}
